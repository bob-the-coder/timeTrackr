var projectModule = (function () {
    function create() {
        var model = new Project();
        model.getData();

        $.post("/Project/Create/",
            model.toPostData(), function() {
                window.location = "/";
            });
    }

    return {
        create: create
    }
}());