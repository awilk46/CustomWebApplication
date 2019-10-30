$("#Search").on("input", function () {

    var searchby = $("#searchby").val();
    var searchVal = $("#Search").val();
    var catId = $("#categoryID").val();
    //var catId = "3";
    var setData = $("#dataSearching");
    setData.html("");
    $.ajax({
        url: "/Default/GetSearchingData",
        type: "get",
        dataType: "json",

        data: {
            categoryID: Number(catId),
            searchBy: searchby,
            searchValue: searchVal
        },
        success: function (result) {

            if (result.length == 0) {
                setData.append('<tr><td colspan="7" style="color: red;">Nie odnaleziono szukanej frazy</td></tr>');
            }
            else {

                for (var i in result) {
                    var Data = "<tr>" +
                        "<td>" + result[i].AlbumID + "</td>" +
                        "<td>" + result[i].AlbumName + "</td>" +
                        "<td>" + result[i].BandName + "</td>" +
                        '<td> <div class="album-cover-edit"><img src="/Content/Images/' + result[i].AlbumCover + ' " alt="Card image cap"></div> </td>' +
                        "<td>" + result[i].Year + "</td>" +
                        "<td>" + parseFloat(result[i].Price) + "</td>" +
                        "<td>" +
                        '<button id="' + result[i].AlbumID + '" type="button" class="btn btn-primary myModals" data-toggle="modal" data-target="#exampleModal-' + result[i].AlbumID + '">' +
                        "Zobacz </button>" +
                        '<div class="modal fade" id="exampleModal-' + result[i].AlbumID + '" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel-' + result[i].AlbumID + '" aria-hidden="true">' +
                        '<div class="modal-dialog" role="document">' +
                        '<div class="modal-content">' +
                        '<div class="modal-header">' +
                        '<h5 class="modal-title" id="exampleModalLabel-' + result[i].AlbumID + '">' + result[i].AlbumName + ", " + result[i].Year + ", " + result[i].BandName + "</h5>" +
                        '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
                        '<span aria-hidden="true">&times;</span> </button> </div>' +
                        '<div id="parent-' + result[i].AlbumID + '" class="modal-body">' +
                        "</div>" +
                        '<div class="modal-footer">' +
                        '<button id="closeModal" type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>' +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</div>" +
                        "</td>" +
                        '<td class="hidden">' +
                        '<input id="categoryID" class="hidden" type="submit" value="' + result[i].CategoryID + '"/>' +
                        "</td>" +
                        "</tr>";
                    setData.append(Data);
                }
                openModal();
            }
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //alert(xhr.responseText);
            alert("Error!!: " + thrownError);
        },
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            return xhr;
        }
    });
});

$(".myModals").on("click", function () {
    var Id = $(this).attr('id');
    var par = "#parent-" + Id;
    var setData = $(par);
    setData.html("");
    $.ajax({
        type: "get",
        url: '/Default/SongListByAlbum',
        data: { albumID: Id },
        dataType: "json",
        cache: false,
        success: function (result) {
            for (var i in result) {
                var data = "<p>" + result[i].SongName + "</p>";
                setData.append(data);
            }
        },
        error: function (response) {
            alert('error');
        }
    });

});
function openModal() {
    $(".myModals").on("click", function () {
        var Id = $(this).attr('id');
        var par = "#parent-" + Id;
        var setData = $(par);
        setData.html("");
        $.ajax({
            type: "get",
            url: '/Default/SongListByAlbum',
            data: { albumID: Id },
            dataType: "json",
            cache: false,
            success: function (result) {
                for (var i in result) {
                    var data = "<p>" + result[i].SongName + "</p>";
                    setData.append(data);
                }
            },
            error: function (response) {
                alert('error');
            }
        });

    });
}