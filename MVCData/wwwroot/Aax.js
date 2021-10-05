function init(){
    console.log("höt/y");

    $("#people").click(function (e) {
        e.preventDefault();
        var _this = $(this);
        alert(_this.attr("href"));
        $.get(_this.attr("href"), function (res) {
            $('#' + _this.data("target")).html(res);
        });
    });

    $("#delete").click(function (e) {
        e.preventDefault();
        
        var _this = $(this);
        var data = _this.attr("href") + '/' + document.getElementById("findId").value;
        alert("Delete: " + data + "/n " + _this.attr("href"));
        $.get(_this.attr("href"), function (res) {
            $('#' + _this.data("target")).html(res);
        });
    });

    $("#details").click(function (e) {
        e.preventDefault();

        var _this = $(this);
        var data = _this.attr("href") + '/' + document.getElementById("findId").value + '_';
        alert("Details:  " + data);
        $.get(_this.attr("href"), function (res) {
            $('#' + _this.data("target")).html(res);
        });
    });

    $("#search").click(function (e) {
        e.preventDefault();
        var _this = $(this);
        //var data = _this.attr("href") + '/' + document.getElementById("searchString").nodeValue();

        $.get(_this.attr("href"), function (res) {
            $('#' + _this.data("target")).html(res);
        });
        
        /*$.get(data, function (res) {
            $('#' + _this.data("target")).html(res);
        });*/
    });

}
