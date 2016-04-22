
var AjaxProcessStatus = {
    SUCCESS: 1,
    ERROR: 2,
    NOTVALID: 3
}

var RequestType = {
    POST: 'POST',
    GET: 'GET'
};

var DataType = {
    XML: 'xml',
    JSON: 'json',
    SCRIPT: 'script',
    HTML: 'html',
    TEXT: 'text'
};

var Configuration = {
    baseUrl: 'http://localhost:4444',
    globalImgPath: '/assets/global/img/'
};

var ConstantMessages = {

    toastrErrorTitle: 'Birşeyler Ters Gitti',
    tostrSuccessTitle: 'İşlem Başarılı',
    blockUISavingMessage: 'Kaydediliyor...'
}


var ToastrTypes = {
    SUCCESS: 'success',
    INFO: 'info',
    WARNING: 'warning',
    ERROR: 'error'
}

var RequestURL = {
    getCommentArea: '/Helper/GetCommentArea',
    sessionCheck: '/Member/SessionCheck'
}