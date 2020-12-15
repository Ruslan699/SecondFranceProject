var dataId = '';
var dataUrl = '';
var callBackUrl = '';


function OnFailure(error) {
    $(':input[type="submit"]').prop('disabled', false);
    $("#loading").css('display', 'none');
    alert(error);
}

function OnLoading() {
    $(':input[type="submit"]').prop('disabled', true);
    $("#loading").css('display', 'inline-block');
}

function ShowRemoveModal(url, id) {
    this.dataUrl = url;
    this.dataId = id;
    this.callBackUrl = callBackUrl;
    $('#removeModalId').modal('show');
    $('#removeFormId').attr('action', url);
    $('#removeDataId').val(id);
}

function ConfirmAnnouncement(id, url) {
    var message = $('#MessageForCustomerId').val();
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: 'post',
        url: url,
        cache: false,
        data: { id: id, message: message, __RequestVerificationToken: __RequestVerificationToken },
        success: function (data) {
            if (data.IsSucceed) {
                location.reload();
                $('#AnnouncementDetailsModalId').modal('hide');
            }
            else
                alert(data.Description);
        },
        error: function () {
            alert('Error!');
        }
    });
}

function RejectAnnouncement(id, url) {
    var message = $('#MessageForCustomerId').val();
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: 'post',
        url: url,
        cache: false,
        data: { id: id, message: message, __RequestVerificationToken: __RequestVerificationToken  },
        success: function (data) {
            if (data.IsSucceed) {
                $('#AnnouncementDetailsModalId').modal('hide');
            }
            else
                alert(data.Description);
        },
        error: function () {
            alert('Error!');
        }
    });
}

function CustomerDetailsModal(url, id) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'html',
        data: { id: id },
        success: function (htmlData) {
            $('#CustomerDetailsBodyModalId').html(htmlData);
            $('#CustomerDetailsModalId').modal('show');
        },
        error: function () {
            alert('Elani gosterende xeta bas verdi!');
        }
    });
}

function BlockCustomer(id, url) {
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();    
    $.ajax({
        type: "post",
        url: url,
        cache: false,
        data: { id: id, __RequestVerificationToken: __RequestVerificationToken },
        success: function (data) {
            if (data.IsSucceed) {
                location.reload();
                $('#CustomerDetailsModalId').modal('hide');
            }
            else
                alert(data.Description);
        },
        error: function () {
            alert('Error!');
        }
    });
}

function UnBlockCustomer(id, url) {
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: "post",
        url: url,
        cache: false,
        data: { id: id, __RequestVerificationToken: __RequestVerificationToken },
        success: function (data) {
            if (data.IsSucceed) {
                location.reload();
                $('#CustomerDetailsModalId').modal('hide');
            }
            else
                alert(data.Description);
        },
        error: function () {
            alert('Error!');
        }
    });
}

function RemovePhone(id, url) {
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    $.ajax({
        type: 'post',
        url: url,
        cache: false,
        data: { id: id, __RequestVerificationToken: __RequestVerificationToken},
        success: function (data) {
            if (data.IsSucceed)
                location.reload();
            else
                alert(data.Description);
        },
        error: function () {
            alert('Error!');
        }
    });
}

function ChangeLang(lang, url) {
    $.ajax({
        url: url,
        type: 'post',
        data: { lang: lang },
        success: function (res) {
            if (res.IsCompleted)
                location.reload();
            else
                alertify.error(res.Description);
        },
        error: function () {
            alertify.error('error');
        }
    });
}

function HrefMe(url, data) {
    location.href = url + '/' + data;
}

function GoBack() {
    window.history.back();
}

function AnnouncementDetailsModal(url, id) {
    $.ajax({
        url: url,
        type: 'GET',
        dataType: 'html',
        data: { id: id },
        success: function (htmlData) {
            $('#AnnouncementDetailsBodyModalId').html(htmlData);
            $('#AnnouncementDetailsModalId').modal('show');
        },
        error: function () {
            alert('Elani gosterende xeta bas verdi!');
        }
    });
}

$('#exampleModal').on('show.bs.modal', function Modal(event) {
    var button = $(event.relatedTarget);
    var recipient = button.data('whatever');
    var modal = $(this);
    modal.find('.modal-title').text('New message to ' + recipient);
    modal.find('.modal-body input').val(recipient);
});


function RemoveAnnouncementImage(url, id) {
    var acceptRemove = confirm("Are you want to delete?");
    let __RequestVerificationToken = $("input[name='__RequestVerificationToken']").val();
    if (acceptRemove === true) {
        $.ajax({
            url: url,
            type: 'post',
            data: { id: id, __RequestVerificationToken: __RequestVerificationToken },
            dataType: 'json',
            success: function (data) {
                if (data.IsSucceed)
                    location.reload();
                else alert(data.Description);
            },
            error: function () {
                alert('Xeta');
            }
        });
    }
}

    