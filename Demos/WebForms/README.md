# GroupDocs.Search for .NET WebForms Example

[![Build status](https://ci.appveyor.com/api/projects/status/av5r3ghcldm5rja7/branch/master?svg=true)](https://ci.appveyor.com/project/bobkovalex/groupdocs-search-for-net-webforms/branch/master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5b55dd6de4a3454d963cfa10f7bbfa58)](https://app.codacy.com/gh/groupdocs-search/GroupDocs.Search-for-.NET-WebForms?utm_source=github.com&utm_medium=referral&utm_content=groupdocs-search/GroupDocs.Search-for-.NET-WebForms&utm_campaign=Badge_Grade_Dashboard)
[![GitHub license](https://img.shields.io/github/license/groupdocs-search/GroupDocs.Search-for-.NET-WebForms.svg)](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET-WebForms/blob/master/LICENSE)

## System Requirements
- .NET Framework 4.5
- Visual Studio 2015

## Document Search API for .NET WebForms
[GroupDocs.Search for .NET](https://products.groupdocs.com/search/net) is a powerful full-text search API that allows you to search through over 70 document formats in your applications. To make it possible to search instantly across thousands of documents, they must be added to the index.

**Note:** without a license application will run in trial mode, purchase [GroupDocs.Search for .NET license](https://purchase.groupdocs.com/order-online-step-1-of-8.aspx) or request [GroupDocs.Search for .NET temporary license](https://purchase.groupdocs.com/temporary-license).

## Supported document Formats

| Family                      | Formats                                                                                                                            |
| --------------------------- |:---------------------------------------------------------------------------------------------------------------------------------- |
| Microsoft Word              | `DOC`, `DOCM` , `DOCX`, `DOT`, `DOTM`, `DOTX`                                                                                      |
| Portable Document Format    | `PDF`                                                                                                                              |
| Microsoft Excel             | `XLS`, `XLSB`, `XLSM`, `XLSX`, `XLT`, `XLTM`, `XLTX`                                                                               |
| Microsoft PowerPoint        | `PPT`, `POT`, `POTM`, `POTX`, `PPS`, `PPSM`, `PPSX`, `PPTM`, `PPTX`                                                                |
| Microsoft Project           | `MPP`                                                                                                                              |
| Microsoft Outlook           | `EML`, `EMLX`, `MSG`                                                                                                               |
| Microsoft OneNote           | `ONE`                                                                                                                              |
| Microsoft Visio             | `VSD`, `VSS`                                                                                                                       |
| OpenDocument Formats        | `ODT`, `ODP`, `ODS`, `OTT`                                                                                                         |
| Photoshop                   | `PSD`                                                                                                                              |
| Metafiles                   | `EMF`, `WMF`                                                                                                                       |
| Image files                 | `BMP`, `EMF`, `GIF`, `JP2`, `JPG`, `PNG`, `PSD`, `TIFF`, `WMF`, `DJVU`                                                             |
| Electronic publication      | `EPUB`, `CHM`, `FB2`                                                                                                               |
| Markup                      | `HTML`, `XHTML`, `MHTML`, `MD`, `XML`                                                                                              |
| Medicine                    | `DCM`                                                                                                                              |
| Audio                       | `MP3`, `WAV`                                                                                                                       |
| Video                       | `AVI`, `MOV`, `QT`, `FLV`, `ASF`                                                                                                   |
| Other                       | `TXT`, `RTF`, `ZIP`, `TORRENT`                                                                                                     |

## Demo Video
Comming Soon

## Features
- Create index on disk
- Update index to take into account changed, deleted and added documents
- Optimize index to improve search performance
- Indexing password protected documents
- Simple word search
- Phrase search
- Search by file-name
- Highlighting search results in the text of the entire document or in text segments
- Responsive design
- Cross-browser support (Safari, Chrome, Opera, Firefox)
- Clean, modern and intuitive design
- Mobile support (open application on any mobile device)

## How to run

You can run this sample by one of following methods

#### Build from source

Download [source code](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET-WebForms/archive/master.zip) from github or clone this repository.

```bash
git clone https://github.com/groupdocs-search/GroupDocs.Search-for-.NET-WebForms
```

Open solution in the VisualStudio.
Update common parameters in `web.config` and example related properties in the `configuration.yml` to meet your requirements.

Open http://localhost:8080/search in your favorite browser

#### Docker image
Comming Soon

### Configuration
For all methods above you can adjust settings in `configuration.yml`. By default in this sample will lookup for license file in `./Licenses` folder, so you can simply put your license file in that folder or specify relative/absolute path by setting `licensePath` value in `configuration.yml`.

#### Search configuration options

| Option                 | Type    |   Default value   | Description                                                                                                                                  |
| ---------------------- | ------- |:------------------|:-------------------------------------------------------------------------------------------------------------------------------------------- |
| **`filesDirectory`**   | String | `DocumentSamples/Search` | Files directory path. Indicates where uploaded and predefined files are stored. It can be absolute or relative path |
| **`indexDirectory`**   | String | `DocumentSamples/Search/Index` | Absolute path to index directory |
| **`indexedFilesDirectory`** | String | `DocumentSamples/Search/Indexed` | Absolute path to indexed files directory |

## Troubleshooting
### How to set custom baseURL
BaseURL is fetched from address bar however you can set custom baseURL by adding *forRoot* parameter at [app.module.ts](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET-WebForms/blob/master/src/client/apps/search/src/app/app.module.ts#L10)

**Example:**
```js
SearchModule.forRoot("http://localhost:8080")
```

## License
The MIT License (MIT). 

Please have a look at the LICENSE.md for more details

## GroupDocs Search on other platforms/frameworks

- .NET MVC [Search](https://github.com/groupdocs-search/GroupDocs.Search-for-.NET-MVC)

## Resources
- **Website:** [www.groupdocs.com](http://www.groupdocs.com)
- **Product Home:** [GroupDocs.Search for .NET](https://products.groupdocs.com/search/net)
- **Product API References:** [GroupDocs.Search for .NET API](https://apireference.groupdocs.com/net/search)
- **Download:** [Download GroupDocs.Search for .NET](http://downloads.groupdocs.com/search/net)
- **Documentation:** [GroupDocs.Search for .NET Documentation](https://docs.groupdocs.com/display/searchnet/Home)
- **Free Support Forum:** [GroupDocs.Search for .NET Free Support Forum](https://forum.groupdocs.com/c/search)
- **Paid Support Helpdesk:** [GroupDocs.Search for .NET Paid Support Helpdesk](https://helpdesk.groupdocs.com)
- **Blog:** [GroupDocs.Search for .NET Blog](https://blog.groupdocs.com/category/search/)
- **Search:** [GroupDocs.Search for .NET Search](https://search.groupdocs.com/)

