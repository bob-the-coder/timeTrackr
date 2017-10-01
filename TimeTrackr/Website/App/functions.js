var functions = {
    getPropsByName: function () {
        var caller = this;
        for (var k in caller) {
            if (!caller.hasOwnProperty(k)) continue;

            caller[k] = $("#" + k.toLowerCase()).val();
        }
    },
    toPostData: function() {
        var self = this;
        return JSON.parse(JSON.stringify(self));
    }
}