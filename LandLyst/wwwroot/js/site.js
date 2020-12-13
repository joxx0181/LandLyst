// Javascript for Slideshow (index page)
// ------------------------------------------------------------------

function slideSwitch() {
    var $active = $('#slideshow IMG.active');

    if ($active.length == 0) $active = $('#slideshow IMG:last');

    var $next = $active.next().length ? $active.next()
        : $('#slideshow IMG:first');

    $active.addClass('last-active');

    $next.css({ opacity: 0.0 })
        .addClass('active')
        .animate({ opacity: 1.0 }, 1000, function () {
            $active.removeClass('active last-active');
        });
}

$(function () {
    setInterval("slideSwitch()", 5000);
});

// Javascript for Expaned images (room page)
// ------------------------------------------------------------------

function expanFunction(imgs) {
    var expandImg = document.getElementById("expandedImg");
    var imgText = document.getElementById("imgtext");
    expandImg.src = imgs.src;
    imgText.innerHTML = imgs.alt;
    expandImg.parentElement.style.display = "block";
}

// Javascript for Selected option and Price calculator (booking page)
// --------------------------------------------------------------------

function getRoomType(select) {
    var form = select.form;
    form.txtRoomType.value = select.options[select.selectedIndex].text;
} 

function doMath() {
    var roomvalue;
    var dayvalue;
    var basicprice = 595;
    var sbedprice = 100;
    var tsbedprice = 200;
    var dbedprice = 200;
    var bathprice = 50;
    var jacprice = 175;
    var kitprice = 350;
    var balprice = 550;
    var calprice;
    var totalprice;

    roomvalue = document.getElementById("txtRoomType").value;
    dayvalue = document.getElementById("txtNumOfNights").value;

    switch (roomvalue) { 
        case "A: single bed":
            calprice = (basicprice + sbedprice);
            break;
        case "B: single bed and bath":
            calprice = (basicprice + sbedprice + bathprice);
            break;
        case "C: single bed and balcony":
            calprice = (basicprice + sbedprice + balprice);
            break;
        case "D: single bed, bath and balcony":
            calprice = (basicprice + sbedprice + bathprice + balprice);
            break;
        case "E: two single beds and bath":
            calprice = (basicprice + tsbedprice + bathprice);
            break;
        case "F: double bed":
            calprice = (basicprice + dbedprice);
            break;
        case "G: double bed and bath":
            calprice = (basicprice + dbedprice + bathprice);
            break;
        case "H: double bed and balcony":
            calprice = (basicprice + dbedprice + balprice);
            break;
        case "I: double bed, bath and jacuzzi":
            calprice = (basicprice + dbedprice + bathprice + jacprice);
            break;
        case "J: double bed, jacuzzi and balcony":
            calprice = (basicprice + dbedprice + jacprice + balprice);
            break;
        case "K: double bed, jacuzzi, balcony and kitchen":
            calprice = (basicprice + dbedprice + jacprice + balprice + kitprice);
            break;
        default:
            break;
    }
    totalprice = parseFloat((calprice) * dayvalue).toFixed(2);
    if (dayvalue >= 7) {
        totalprice = parseFloat(((calprice) * 0.9) * dayvalue).toFixed(2);
    }
    document.getElementById("txtPrice").value = totalprice;
}

// Javascript for password protected (staffLogin page)
// --------------------------------------------------------------------

function TheLogin() {   
    var passReception = 'pj9999';
    var passReception1 = 'hp9999';
    var passReception2 = 'mj9999';
    var passReception3 = 'vh9999';
    var passReception4 = 'ml9999';


    if (this.document.login.pass.value == passReception || this.document.login.pass.value == passReception1 || this.document.login.pass.value == passReception2 || this.document.login.pass.value == passReception3 || this.document.login.pass.value == passReception4) {
        top.location.href = 'StaffReception';
    }
    else {
        window.alert("Incorrect password, please try again.");
    }
}

function TheLogin2() {
    var passRoomCleaning = 'ls9999';
    var passRoomCleaning1 = 'mj9999';

    if (this.document.login2.pass2.value == passRoomCleaning || this.document.login2.pass2.value == passRoomCleaning1) {
        top.location.href = 'StaffRoomCleaning';
    }
    else {
        window.alert("Incorrect password, please try again.");
    }
}
