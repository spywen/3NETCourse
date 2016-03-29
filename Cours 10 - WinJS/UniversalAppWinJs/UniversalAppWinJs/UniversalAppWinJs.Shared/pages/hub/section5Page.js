(function () {
    "use strict";

    var ControlConstructor = WinJS.UI.Pages.define("/pages/hub/section5Page.html", {
        // Cette fonction est appelée une fois que le contenu du contrôle de page 
        // a été chargé, que les contrôles ont été activés et que 
        // les éléments résultants ont été apparentés au modèle DOM. 
        ready: function (element, options) {
            options = options || {};
        },
    });

    var items = [
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" }
    ];

    var itemsGrouped = new WinJS.Binding.List([
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" },
        { title: "Banana Blast", text: "Low-fat frozen yogurt", picture: "/images/fruits/60Banana.png" },
        { title: "Lavish Lemon Ice", text: "Sorbet", picture: "/images/fruits/60Lemon.png" },
        { title: "Marvelous Mint", text: "Gelato", picture: "/images/fruits/60Mint.png" },
        { title: "Creamy Orange", text: "Sorbet", picture: "/images/fruits/60Orange.png" },
        { title: "Succulent Strawberry", text: "Sorbet", picture: "/images/fruits/60Strawberry.png" },
        { title: "Very Vanilla", text: "Ice Cream", picture: "/images/fruits/60Vanilla.png" }
    ]);

    var grouped = itemsGrouped.createGrouped(
        //getGroupKey : return the key of a group of data (here: first letter of title)
        function (item) {
            return item.title.toUpperCase().charAt(0);
        },
        //getGroupData : return category name (here: letter)
        function (item) {
            return {
                title: item.title.toUpperCase().charAt(0)
            };
        },
        //compareGroups : sort data inside group of data
        //charCodeAt => https://developer.mozilla.org/fr/docs/Web/JavaScript/Reference/Objets_globaux/String/charCodeAt
        function (left, right) {
            return left.charCodeAt(0) - right.charCodeAt(0);
        });

    // Les lignes suivantes exposent ce constructeur de contrôle comme global. 
    // Cela vous permet d'utiliser le contrôle comme un contrôle déclaratif dans 
    // l'attribut data-win-control. 

    WinJS.Namespace.define("HubApps_SectionControls", {
        Section5Control: ControlConstructor,
        data: new WinJS.Binding.List(items),
        groupedData: grouped
    });
})();