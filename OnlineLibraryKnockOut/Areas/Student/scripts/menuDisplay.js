var self = null;
var MenuDisplayViewModel = function () {
    self = this;
    self.menuData = ko.observable(null);
    GetCallProcess("/Areas/Student/config/menuList.json", onSuccess);
};
function onSuccess(params) {
    self.menuData(params.Student[0]);
    console.log(params.Student[0])
}

ko.applyBindings(new MenuDisplayViewModel());