var self = null;


function MenuDisplayViewModel() {
    self = this;
    self.menuData = ko.observable(null);
    GetCallProcess("/Areas/Admin/config/menuList.json", onSuccess);
}

function onSuccess(params) {
    self.menuData(params.Admin[0]);
}