var bindObjects = {
    sideMenu: document.getElementById('sideMenuContainer') ? new MenuDisplayViewModel() : null,
    BranchScripts: document.getElementById('Add_new_Branch') ? new branchFnc() : null
}


ko.applyBindings(bindObjects);