uiExample = {
    messages: {},
    urls: {
        startPage: "/Home/Index/",
        initModel: "/Home/InitModel/",
        loadDocument: "/Home/LoadDocument/",
        createIndex: "/Home/CreateIndex/",
        deleteIndex: "/Home/DeleteIndex/",
        addFolderToIndex: "/Home/AddFolderToIndex/",
        runSearch: "/Home/RunSearch/",
        getDefaultFolders: "/Home/GetDefaultFolders/",
    },

    init: function () {

    },

    selectFolder: function(callBack) {
        swal({
            title: 'Enter folder name',
            input: 'text',
            showCancelButton: true,
            confirmButtonText: 'Add to index'

        }).then(callBack);
    },

    showMessage: function(folderName) {
        swal(
            'Folder has been added to index',
            folderName,
            'success'
        );
    },
};

$(uiExample.init);