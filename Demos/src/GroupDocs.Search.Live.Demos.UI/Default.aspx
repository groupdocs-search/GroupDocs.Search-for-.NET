<%@ Page Title="" Language="C#" MetaDescription="Index your data and perform text Searchin all Popular document formats online from anywhere" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Search.Live.Demos.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<link rel="stylesheet" href="https://products.groupdocs.app/css/bootstrap.min.css" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://products.groupdocs.app/js/bootstrap.min.js"></script>
	<script type="text/javascript">

		function ShowPopup() {
			$("#btnShowPopup").click();
		}
		function PerformSearchOnSameFiles() {
			$('.fileupload').hide();
			var fileName = document.getElementById('<%= hdnFileNames.ClientID %>').value;
			var arrFileNames = fileName.split("?");
			var i;
			var fileList = $('.filename');
			fileList.empty();
			//fileList.append($("<label>").text(fileName));
			$('.fileupload').show();
			for (i = 0; i < arrFileNames.length; i++) {

				fileList.append($("<label>").text(arrFileNames[i]));
			}
			document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
		}

		function SetSearchOptions() {
			var x = document.getElementById('<%= ddlSearchType.ClientID %>').value;
			document.getElementById('lblCaseSensitive').style.display = "inline";

			if (x == "Boolean") {
				//document.getElementById('div2ndTerm').style.display = "inline";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "First Term OR Second Term");
				//document.getElementById('<%= txtSecondTerm.ClientID %>').setAttribute("placeholder", "Second Term");

			}
			else if (x == "Regex") {
				document.getElementById('div2ndTerm').style.display = "inline";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "Relevant Key");
				document.getElementById('<%= txtSecondTerm.ClientID %>').setAttribute("placeholder", "^text");
			}
			else if (x == "Faceted") {
				document.getElementById('div2ndTerm').style.display = "none";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "Content:Search Text");
			}
			else if (x == "Exact Phrase") {
				document.getElementById('div2ndTerm').style.display = "none";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "\\exact search query\\");
			}
			else if (x == "Blended Characters") {
				document.getElementById('div2ndTerm').style.display = "inline";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "silver-gray");
				document.getElementById('<%= txtSecondTerm.ClientID %>').setAttribute("placeholder", "Blended character -");
			}
			else if (x == "Wildcard") {
				document.getElementById('div2ndTerm').style.display = "none";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "?ffect & princip?(2~4)");
			}
			else if (x == "Numeric Range") {
				document.getElementById('lblCaseSensitive').style.display = "none";
				document.getElementById('div2ndTerm').style.display = "none";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "13~~42");
			}
			else {
				document.getElementById('div2ndTerm').style.display = "none";
				document.getElementById('<%= txtSearchString.ClientID %>').setAttribute("placeholder", "Search Text");
			}
		}

	</script>


	<div class="container-fluid GroupDocsApps">
		<div class="container">
			<div class="row">
				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>
						<div class="col-md-12 pt-5 pb-5">
							<h1 id="hheading" runat="server">Free Online Document Search</h1>
							<h4 id="hdescription" runat="server">Index your data and perform text Search in all popular document formats online from anywhere</h4>
							<div class="form">
								<asp:HiddenField ID="hdnFileNames" runat="server" Value="" />
								<asp:HiddenField ID="hdnSearchFromSameFiles" runat="server" Value="" />
								<asp:PlaceHolder ID="ConvertPlaceHolder" runat="server">
									<div class="uploadfile">
										<div class="filedropdown">
											<div class="filedrop">
												<label class="dz-message needsclick"><% = Resources["DropOrUploadFileSearchApp"] %></label>
												<input type="file" name="UploadFile" multiple="multiple" id="UploadFile" runat="server" class="uploadfileinput" />
												<asp:RegularExpressionValidator ID="ValidateFileType" ValidationExpression="([a-zA-Z0-9\s)\s(\s_\\.\-:])+(.doc|.docx|.dot|.dotx|.rtf)$"
													ControlToValidate="UploadFile" runat="server" ForeColor="Red"
													Display="Dynamic" />
												<asp:RequiredFieldValidator ID="rfvFile" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
													ErrorMessage="*" ControlToValidate="UploadFile" Display="Dynamic"
													ForeColor="Red"></asp:RequiredFieldValidator>
												<asp:HiddenField ID="hdnFileExtensionMessage" runat="server" />
												<div class="fileupload">
													<span class="filename"></span>
												</div>
											</div>
											<div class="watermark">
												<div class="form-inline">
													<div class="color-wrapper">
														<label class="checkbox" style="font-size: 24px !important; font-weight: normal; color: #fff;" id="lblCaseSensitive">

															<asp:CheckBox ID="chkCaseSensitive" runat="server" />
															<i></i><% = Resources["CaseSensitiveSearch"]%>
														</label>

														<textarea id="txtSearchString" runat="server" placeholder='Search Text' class="form-control" aria-describedby="basic-addon2"></textarea>
													</div>
												</div>

											</div>
											<div class="watermark" id="div2ndTerm" style="display: none;">

												<textarea id="txtSecondTerm" placeholder='Second Term' runat="server" style="margin-bottom: 20px; max-width: 625px" class="form-control" aria-describedby="basic-addon2"></textarea>



											</div>
											<div>
												<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
													<ProgressTemplate>
														<div>
															<img height="59px" width="59px" alt="Please wait..." src="../../img/loader.gif" />
														</div>
													</ProgressTemplate>
												</asp:UpdateProgress>
											</div>
											<p runat="server" id="pMessage"></p>
											<div class="saveas">
												<em><%= Resources["GroupDocsSearchType"] %></em>
												<div class="btn-group saveformat">
													<asp:DropDownList ID="ddlSearchType" onchange="SetSearchOptions()" CssClass="btn" runat="server">
													</asp:DropDownList>
												</div>
											</div>
											<div class="convertbtn">
												<asp:Button runat="server" ID="btnSearch" ValidationGroup="uploadFile" class="btn btn-success btn-lg" Text="SEARCH NOW" OnClick="btnSearch_Click" />
											</div>

										</div>
									</div>
								</asp:PlaceHolder>




							</div>

						</div>
					</ContentTemplate>
					<Triggers>
						<asp:PostBackTrigger ControlID="btnSearch" />
					</Triggers>
				</asp:UpdatePanel>

			</div>
		</div>
		<button type="button" class="btn btn-primary" style="display: none;" id="btnShowPopup" data-toggle="modal" data-target="#exampleModalCenter">
			Launch demo modal
		</button>
		<div class="modal fade" style="padding-top: 150px;" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
			<div class="modal-dialog modal-dialog-centered" role="document">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title"><b><% = Resources["SearchResults"] %></b></h5>
						<%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>--%>
					</div>
					<div class="modal-body">
						<asp:Literal ID="ltSearchResults" runat="server" Mode="PassThrough"></asp:Literal>
					</div>
					<div class="modal-footer">
						<asp:Button CssClass="btn btn-success" OnClick="btnPerformSearchOnSameFiles_Click" runat="server" ID="btnPerformSearchOnSameFiles" Text="Search in Uploaded Files" />
						<button type="button" class="btn btn-danger" data-dismiss="modal">Refresh & Close</button>

					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="col-md-12 pt-5 bg-gray tc" style="padding-bottom: 0px!important;" id="dvAllFormats" runat="server">
		<div class="container">
			<div class="col-md-12 pull-left">
				<h2 class="h2title"><%= Resources["GroupDocsSearch"] %> App</h2>
				<p><%= Resources["GroupDocsSearch"] %> App Supported Document Formats</p>
				<div class="diagram1 d2 d1-net">
					<div class="d1-row">
						<div class="d1-col d1-left">
							<header>Microsoft Office Formats</header>
							<ul>
								<li><strong>Word:</strong> DOC, DOCX, DOCM, DOT, DOTX, DOTM</li>
								<li><strong>Excel:</strong> XLS, XLSX, XLSM, XLTX, XLTM, XLSB</li>
								<li><strong>PowerPoint:</strong> PPT, PPTX, POT, POTX, PPS, PPSX, PPTM, PPSM</li>
								<li><strong>Microsoft Compiled HTML:</strong> CHM</li>
								<li><strong>OneNote:</strong> ONE</li>

							</ul>
						</div>
						<!--/left-->
						<div class="d1-col d1-right">
							<header>OpenDocument & Other Formats</header>
							<ul>
								<li><strong>Portable Document Format:</strong> PDF</li>
								<li><strong>OpenOffice Document:</strong> ODT, OTT</li>
								<li><strong>OpenOffice Spreadsheet:</strong> ODS</li>
								<li><strong>OpenOffice Presentation:</strong> ODP</li>
								<li><strong>Email:</strong> PST, OST, MSG, EML, EMLX</li>
								<li><strong>Text:</strong> TXT</li>
								<li><strong>Electronic Publishing:</strong> EPUB</li>
								<li><strong>FictionBook:</strong> FB2</li>
								<li><strong>ZIP Archives:</strong> ZIP</li>
								<li><strong>Rich Text Format:</strong> RTF</li>
							</ul>
						</div>
						<!--/right-->
					</div>
					<!--/row-->
					<div class="d1-logo">
						<img src="../img/groupdocs-search-net.png" alt=".NET Files Search API"><header>GroupDocs.Search</header>
						<footer><small>App</small></footer>
					</div>
					<!--/logo-->
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
		<div class="col-md-6 cardbox tc col-md-offset-3 b6">
			<h3 runat="server" id="hExtension1"></h3>
			<p runat="server" id="hExtension1Description"></p>
		</div>
	</div>

	<!-- HowTo Section -->
	<div class="col-md-12 tl bg-darkgray howtolist">
		<div class="container tl dflex">

			<div class="col-md-4 howtosectiongfx">
				<img src="/img/howto.png">
			</div>
			<div class="howtosection col-md-8">
				<div>
					<h4><i class="fa fa-question-circle "></i>&nbsp;<b>How to search in <%=fileFormat  %>document using GroupDocs Search App</b></h4>
					<ul>
						<li>Click inside the file drop area to upload a <%=fileFormat  %>file or drag & drop a <%=fileFormat  %>file.</li>
						<li>Select "Search Type" and enter the value accordingly.</li>
						<li>Click "Search Now" for searching.</li>
					</ul>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pt-5 app-features-section">
		<div class="container tc pt-5">
			<div class="col-md-4">
				<div class="imgcircle fasteasy">
					<img src="../../img/fast-easy.png" />
				</div>
				<h4><%= string.Format( Resources["WatermarkFeature1"], "Search Text") %></h4>
				<p><%= Resources["SearchTextFeature1Description"] %></p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle anywhere">
					<img src="../../img/anywhere.png" />
				</div>
				<h4>Search Text from Anywhere</h4>
				<p><%= Resources["Feature2Description"] %>.</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle quality">
					<img src="../../img/quality.png" />
				</div>
				<h4>Search Quality</h4>
				<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a><%= Resources["Feature3Description"] %>.</p>
			</div>
		</div>
	</div>

	<script type="text/javascript">
		window.onsubmit = function () {
			if (Page_IsValid) {

				var updateProgress = $find("<%= UpdateProgress1.ClientID %>");
				if (updateProgress) {
					window.setTimeout(function () {
						updateProgress.set_visible(true);
						document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
					}, 100);
				}


			}
		}
	</script>
	<script>
		$(document).ready(function () {
			bindEvents();
		});

		Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
			bindEvents();
		});

		function bindEvents() {

			if (document.getElementById('<%= hdnSearchFromSameFiles.ClientID %>').value == "") {
				$('.fileupload').hide();
			}
			$('#<%= UploadFile.ClientID %>').change(function () {
				$('.fileupload').hide();
				var input = $('.uploadfileinput');
				var fileList = $('.filename');
				fileList.empty();
				for (var i = 0; i < input[0].files.length; i++) {
					fileList.append($("<label>").text(input[0].files[i].name));
				}
				$('.fileupload').show();
				document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
			});

			if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

				var swiper = new Swiper('.swiper-container', {
					slidesPerView: 5,
					spaceBetween: 20,
					// init: false,
					pagination: {
						el: '.swiper-pagination',
						clickable: true,
					},
					navigation: {
						nextEl: '.swiper-button-next',
						prevEl: '.swiper-button-prev',
					},
					breakpoints: {
						868: {
							slidesPerView: 4,
							spaceBetween: 20,
						},
						668: {
							slidesPerView: 2,
							spaceBetween: 0,
						}
					}
				});
			}
		}
	</script>


</asp:Content>
