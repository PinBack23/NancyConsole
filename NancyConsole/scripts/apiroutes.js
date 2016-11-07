var abrHelper = (function () {
    //var lsRootUrl = 'http://localhost:8099/';
    var lsRootUrl = 'http://' + location.host + '/';

    //alert(location.host);
    //alert(location.hostname);

    var URLS = {
        ApiGetMitarbeiter: undefined,
        ApiGetKunden: undefined
    };

    URLS.ApiGetMitarbeiter = lsRootUrl + "Mitarbeiter";
    URLS.ApiGetKunden = lsRootUrl + "Kunde";

    return {
        URLS: URLS
    };
}());