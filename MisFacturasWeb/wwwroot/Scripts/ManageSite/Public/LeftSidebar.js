function validateMenuOption(menuName, tag) {
    var Menu = ListaMenu.urlMenu.find(x => x == menuName)
    var ExisteMenu = Menu != undefined;
    if (ExisteMenu == false)
    {
        tag.style.display = "none";
    }
}
$(function () {
    $('a[onload]').trigger('onload');
});
