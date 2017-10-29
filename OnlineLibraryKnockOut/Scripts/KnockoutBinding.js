function masterVM () {
   
    if (document.getElementById('sideMenuContainer')) {
        this.sideMenu = new MenuDisplayViewModel();
    }
    if (document.getElementById('Add_new_Branch')) {
        this.BranchScripts = new BranchScripts();
    }
};

ko.applyBindings(new masterVM());