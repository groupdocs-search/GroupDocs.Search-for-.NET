using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Globalization;
using GroupDocs.Search.Live.Demos.UI.Models;
using GroupDocs.Search.Live.Demos.UI.Config;
using GroupDocs.Search.Live.Demos.UI.Helpers;
using System.Text.RegularExpressions;

namespace GroupDocs.Search.Live.Demos.UI
{
	public partial class Default : BasePage
	{
		string logMsg = "";
		public string fileFormat = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				btnSearch.Text = Resources["btnSearch"];

				// Set page settings based on from and top selection
				PageSettings();

				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];

			}

		}

		private void SetFileTypeAllowedExtensions()
		{
			string validationExpression = "";
			string validFileExtensions = "";

			Page.MetaDescription = "Free online {ext} document search. Search within {ext} document with multiple search type options, view search results instantly.";
			Page.Title = "Free Online Search In Documents - GroupDocs.App";

			validationExpression = Resources["GroupDocsSearchValidationExpression"];
			validFileExtensions = GetValidFileExtensions(validationExpression);
            
			ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression + "|" + validationExpression.ToUpper() + ")$";
			ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + validFileExtensions;
			aPoweredBy.InnerText = "GroupDocs.Search";
			aPoweredBy.HRef = "https://products.GroupDocs.com/search";
		}
		protected void btnPerformSearchOnSameFiles_Click(object sender, EventArgs e)
		{
			ViewState["PerformSearchOnSameFiles"] = "true";
			hdnSearchFromSameFiles.Value = "true";
			rfvFile.Enabled = ValidateFileType.Enabled = false;
			ClientScript.RegisterStartupScript(this.GetType(), "alert", "PerformSearchOnSameFiles();", true);
		}
		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}
		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}
		private void PageSettings()
		{
			// Add search type items
			ddlSearchType.Items.Insert(0, Resources["SimpleSearch"]);
			ddlSearchType.Items.Insert(1, Resources["BooleanSearch"]);
			ddlSearchType.Items.Insert(2, Resources["RegexSearch"]);
			ddlSearchType.Items.Insert(3, Resources["FuzzySearch"]);
			ddlSearchType.Items.Insert(4, Resources["FacetedSearch"]);
			ddlSearchType.Items.Insert(5, Resources["NumericRangeSearch"]);
			ddlSearchType.Items.Insert(6, Resources["ExactPhraseSearch"]);
			ddlSearchType.Items.Insert(7, Resources["BlendedCharactersSearch"]);
			ddlSearchType.Items.Insert(8, Resources["WildcardSearch"]);
			SetFileTypeAllowedExtensions();
		}
		protected void PerformSearch(string folderID)
		{
			if (folderID.Trim() != "")
			{
				ViewState["PerformSearchOnSameFiles"] = "false";
				Dictionary<string, string> apiParams = new Dictionary<string, string>();

				if (ddlSearchType.SelectedItem.Text == Resources["BlendedCharactersSearch"])
				{
					apiParams.Add("searchString", txtSearchString.Value);
					apiParams.Add("blendedcharacter", txtSecondTerm.Value);

				}
				else if (ddlSearchType.SelectedItem.Text == Resources["RegexSearch"])
				{
					apiParams.Add("relevantKey", txtSearchString.Value);
					apiParams.Add("searchString", txtSecondTerm.Value);
				}
				else
				{
					apiParams.Add("searchString", txtSearchString.Value);
				}
				if (ddlSearchType.SelectedItem.Text != Resources["NumericRangeSearch"])
				{
					apiParams.Add("caseSensitive", chkCaseSensitive.Checked.ToString());

				}

				Response response = null;

                response = GroupDocsSearchApiHelper.Search(folderID, ddlSearchType.SelectedItem.Text, apiParams);

				if (response == null)
				{
					throw new Exception(Resources["APIResponseTime"]);
				}
				else if (response.StatusCode == 200)
				{
					if (response.Results.Count > 0)
					{
						foreach (string file in response.Results)
						{

							ltSearchResults.Text += file;
						}
					}
					else

					{
						ltSearchResults.Text += "No results found";
					}
					txtSearchString.Value = txtSecondTerm.Value = "";
					ddlSearchType.SelectedIndex = 0;
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
				}
				else
				{
					pMessage.Visible = true;
					pMessage.InnerHtml = response.Status;
					pMessage.Attributes.Add("class", "alert alert-danger");
				}
			}
		}
		protected void btnSearch_Click(object sender, EventArgs e)
		{
            Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

            if (Page.IsValid)
			{
				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				string folderID = "";
				ltSearchResults.Text = "";
				FileUploadResult isFileUploaded = null;
				hdnSearchFromSameFiles.Value = "";
				rfvFile.Enabled = ValidateFileType.Enabled = true;

				try
				{
					// Check whether search is on same files
					if ((ViewState["PerformSearchOnSameFiles"] != null) && (ViewState["PerformSearchOnSameFiles"].ToString() == "true"))
					{
						PerformSearch(ViewState["folderID"].ToString());
						return;
					}
					hdnFileNames.Value = "";
					// Access the Files
					for (int i = 0; i < Request.Files.Count; i++)
					{
						HttpPostedFile postedFile = Request.Files[i];

						// Check if File is available
						if (postedFile != null)
						{
							string fn = Regex.Replace(System.IO.Path.GetFileName(postedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
							fn = fn.Replace(" ", String.Empty);

							if (hdnFileNames.Value == "")
							{
								hdnFileNames.Value = fn;
							}
							else
							{
								hdnFileNames.Value += "?" + fn;
							}
							if (fn.Trim() != "")
							{

								string SaveLocation = Configuration.AssetPath + fn;
								// Save file to Aspose.App.UI
								postedFile.SaveAs(SaveLocation);

								if (folderID.Trim() == "")
								{
									// Call FileManager to upload file using Aspose.API URI
									isFileUploaded = FileManager.UploadFile(SaveLocation, "");
									if (isFileUploaded != null)
									{
										folderID = isFileUploaded.FolderId;
									}
								}
								else
								{
									isFileUploaded = FileManager.UploadFileToFolder(SaveLocation, "", folderID);

								}

							}
							else
							{
								pMessage.Visible = true;
								pMessage.InnerHtml = Resources["FileSelectMessage"];
								pMessage.Attributes.Add("class", "alert alert-danger");
							}
						}
					}

					if ((isFileUploaded != null) && (folderID.Trim() != ""))
					{
						ViewState["folderID"] = folderID;
						PerformSearch(folderID);
					}
				}
				catch (Exception ex)
				{
					pMessage.Visible = true;
					pMessage.InnerHtml = "Error: " + ex.Message;
					pMessage.Attributes.Add("class", "alert alert-danger");
				}
			}
		}
	}
}
