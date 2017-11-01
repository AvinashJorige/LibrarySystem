var bindObjects = {
    sideMenu: document.getElementById('sideMenuContainer') ? new MenuDisplayViewModel() : null,
    BranchScripts: document.getElementById('Add_new_Branch') ? new branchFnc() : null,
    BranchList: document.getElementById('Branch_list_display') ? new branchListFnc() : null,
}

$(document).ready(function () {
    bindingAll();
})

function bindingAll() {
    ko.applyBindings(bindObjects);
}
