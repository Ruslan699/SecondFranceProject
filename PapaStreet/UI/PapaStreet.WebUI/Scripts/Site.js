function OnFailure(error) {
    $("#loading").css('display', 'none');
    alert('error');
}

function OnLoading() {
    $("#loading").css('display', 'inline-block');
}

function goHistoryBack() {
    window.history.back();
}

var dataId = '';
var dataUrl = '';
var callBackUrl = '';

function dataForm(url, id) {
    location.href = url + '?id=' + id;
}

function showRemoveModal(url, id) {
    this.dataUrl = url;
    this.dataId = id;
    this.callBackUrl = callBackUrl;
    $('#removeModal').modal('show');
}

function onRemoveModalConfirm() {
    deleteData(dataUrl, dataId);
}

function deleteData(url, id) {
    $.ajax({
        type: 'post',
        url: url,
        dataType: 'json',
        data: { id: id },
        success: function (res) {
            if (res.IsCompleted)
                location.href = location.href;
            else
                alert(res.Description);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    });
}

function PricePlanDetailsModal(url) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'html',
        success: function (htmlData) {
            $('#Priceplancontext').html(htmlData);
            $('#exampleModal').modal('show');
        },
        error: function () {
            alert('');
        }
    });
}

function Register(url,id) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'html',
        data: {id:id},
        success: function (htmlData) {
            window.location.href = '/register'
        },
        error: function () {
            alert('');
        }
    });
}

