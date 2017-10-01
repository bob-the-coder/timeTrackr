Array.prototype.any = function (f) {
    if (typeof f !== "function") return this.length > 0;
    for (var i = 0; i < this.length; i++) {
        if (f(this[i])) return true;
    }
    return false;
}

Array.prototype.selectDistinct = function (f) {
    if (typeof f !== "function") return [];
    var self = this;
    var res = [];
    for (var i = 0; i < self.length; i++) {
        var fi = f(self[i]);
        if (res.any(e => JSON.stringify(e) === JSON.stringify(fi))) continue;
        res.push(fi);
    }
    return res;
}

Array.prototype.where = function(f) {
    if (typeof f !== "function") return [];
    var res = [];
    for (var i = 0; i < this.length; i++) {
        if (f(this[i])) res.push(this[i]);
    }
    return res;
}

Array.prototype.sum = function(f) {
    if (typeof f !== "function") return 0;
    var res = 0;
    for (var i = 0; i < this.length; i++) {
        var v = +f(this[i]);
        if (isNaN(v)) v = 0;
        res += v;
    }
    return res;
}