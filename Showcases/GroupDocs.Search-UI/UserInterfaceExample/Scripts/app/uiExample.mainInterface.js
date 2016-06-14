uiExample.mainInterface = {
    viewModel: {},
    init: function() {
        var self = uiExample.mainInterface;
        self.viewModel = {
            searchResults: ko.observableArray(),
            indexFolder: ko.observable(),
            currentDocumentContent: ko.observable(),
            indexes: ko.observableArray(),
            logRecords: ko.observable(),
            selectedIndex: ko.observable(),
            selectedIndexId: ko.observable(),
            searchQuery: ko.observable(),
            addedFolder: ko.observable(),
            defaultIndexFolder: ko.observable(),
            defaultDocumentsFolder: ko.observable(),

            runViewer: function (data) {
                if (!(data === undefined || data === null)) {
                    uiExample.ajaxProxy.loadDocument(ko.toJSON(data), self.viewModel.showDocument);
                }
            },

            createIndex: function () {
                uiExample.ajaxProxy.createIndex(ko.toJSON(self.viewModel), self.viewModel.fillIndexTable);
                self.viewModel.indexFolder("");
            },
            selectFolder: function () {
                uiExample.selectFolder(self.viewModel.addDocumentsToIndex);
            },
            addDocumentsToIndex: function (indexItem) {
                uiExample.ajaxProxy.addFolderToIndex(ko.toJSON(indexItem), self.viewModel.fillIndexTable);
            },
            deleteIndex: function (data) {
                uiExample.ajaxProxy.deleteIndex(ko.toJSON(data), self.viewModel.fillIndexTable);
            },
            clearLog: function (data) {
                logRecords("");
            },

            runSearch: function () {
                uiExample.ajaxProxy.runSearch(ko.toJSON(self.viewModel), self.viewModel.fillSearchResults);
            },
            prevResult: function () {
                $("#documentContent").contents().text().search(self.viewModel.searchQuery()).wrap("<h1>");
            },
            nextResult: function () {
                var term = self.viewModel.searchQuery();
                var content = $('#documentContent').contents().find('html').text();
                var regex = new RegExp(term, "gi");
                content = content.replace(regex, '<h1>' + term + '</h1>');
                $('#documentContent').contents().find('html').html(content);
            },

            startFolderAdding: function (data) {
                var viewModel = self.viewModel;
                for (var i = 0, len = viewModel.indexes().length; i < len; i++) {
                    viewModel.indexes()[i].isFolderAdding(false);
                }
                data.isFolderAdding(true);
            },
            cancelFolderAdding: function(data) {
                data.isFolderAdding(false);
            },

            selectIndex: function (data) {
                var viewModel = self.viewModel;
                for (var i = 0, len = viewModel.indexes().length; i < len; i++) {
                    viewModel.indexes()[i].isChecked(false);
                    viewModel.indexes()[i].isFolderAdding(false);
                }
                data.isChecked(true);
                viewModel.selectedIndex(data);
                viewModel.selectedIndexId(data.indexId);
            },
            

            fillIndexTable: function (source) {
                var viewModel = self.viewModel;
                viewModel.indexes.removeAll();
                source.Content.forEach(function outputItem(item, i, arr) {
                    var indexItem = viewModel.createIndexItem(item);
                    viewModel.indexes.push(indexItem);
                });
                viewModel.selectedIndex(null);
                viewModel.selectedIndexId(null);
                viewModel.searchQuery("");
            },


            fillSearchResults: function (source) {
                var viewModel = self.viewModel;
                viewModel.searchResults.removeAll();
                source.Content.forEach(function outputItem(item, i, arr) {
                    var resultItem = viewModel.createResultItem(item);
                    viewModel.searchResults.push(resultItem);
                });
            },

            fillDefaultFolders: function (source) {
                var viewModel = self.viewModel;
                viewModel.defaultIndexFolder(source.Content.DefaultIndexFolder);
                viewModel.defaultDocumentsFolder(source.Content.DefaultDocumentsFolder);
            },

            createResultItem: function(source) {
                var item = {
                    fileName: ko.observable(source.FileName),
                    fullName: ko.observable(source.FullName),
                    relevance: ko.observable(source.Relevance)
                };
                return item;
            },

            createIndexItem: function (source) {
                var item = {
                    indexId: ko.observable(source.IndexId),
                    indexFolder: ko.observable(source.IndexFolder),
                    fullIndexFolder: ko.observable(source.FullIndexFolder),
                    inMemory: ko.observable(source.InMemory),
                    isChecked: ko.observable(),
                    folderName: ko.observable(self.viewModel.defaultDocumentsFolder()),
                    isFolderAdding: ko.observable(false),
            };
                return item;
            },

            showDocument: function (data) {
                var viewModel = self.viewModel;
                $('#documentContent').contents().find('html').html("");
                if (data.Content.pageHtml.length > 0) {

                    var term = self.viewModel.searchQuery();
                    var content = data.Content.pageHtml[0];
                    var regex = new RegExp(term, "gi");
                    content = content.replace(regex, '<mark>' + term + '</mark>');
                    $('#documentContent').contents().find('html').html(content);

                    //$('#documentContent').contents().find('html').html(data.Content.pageHtml[0]);
                };



                //$("#documentContent").mark(viewModel.searchQuery());
            },
        };

        uiExample.ajaxProxy.getDefaultFolders(self.viewModel.fillDefaultFolders);
        uiExample.ajaxProxy.initModel(self.viewModel.fillIndexTable);
        ko.applyBindings(self.viewModel, document.getElementById("UserInterface"));
    }
};
$(uiExample.mainInterface.init);
