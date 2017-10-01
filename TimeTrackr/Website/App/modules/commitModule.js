var commitModule = (function () {
    function create() {
        var model = new Commit();
        model.getData();
        
        $.post("/Commit/Create",
            model.toPostData(),
            function (response) {
                window.location = "/Project/Details/" + model.ProjectId;
            });
    }

    return {
        create: create
    }
}());