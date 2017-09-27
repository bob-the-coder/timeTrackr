var functions = {
    getPropsByName: function () {
        var caller = this;
        for (var k in caller) {
            if (!caller.hasOwnProperty(k)) continue;

            caller[k] = $("#" + k.toLowerCase());
        }
    }
}