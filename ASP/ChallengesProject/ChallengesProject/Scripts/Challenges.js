var Challenges = (function () {

    var StatusType = {

        Pending: 0,
        Accepted: 1,
        Declined: 2
    }

    var GetChallengeUserBtnName = function (status) {
        switch (status) {
            case StatusType.Accepted:
                return "Accepted";
            case StatusType.Pending:
                return "Pending";
            case StatusType.Declined:
                return "Declined";
            default:
                return "Challenge";
        }
    }

    var GetChallengeUserBtnClass = function (status) {
        switch (status) {
            case StatusType.Accepted:
                return "btn-success disabled";
            case StatusType.Pending:
                return "btn-info disabled";
            case StatusType.Declined:
                return "btn-warning disabled";
            default:
                return "btn-secondary disabled";
        }
    }

    //public: Change the class of the btn
    var ChangeChallengeUserBtn = function (btn, status) {        
        var btnTagName = btn.prop("tagName");
        //Change the classes of the button
        btn.removeClass("btn-success btn-info btn-default btn-warning btn-secondary btn-error");
        var classes = GetChallengeUserBtnClass(status);
        btn.addClass(classes);
        var btnName = GetChallengeUserBtnName(status);
        //Change the text of the  button
        switch (btnTagName) {
            case "A":
                btn.text(btnName);
                break;
            case "INPUT":
                btn.val(btnName);
            default:
                btn.val(btnName);
        }
    }

    var ShowError = function (message) {
        $('#GlobalStatusMessageText').text(message)
        $('#GlobalStatusMessage').slideDown();
    }

    //public: Challenge myself callback
    var ChallengeMyselfCallback = function (response) {
        ChangeChallengeUserBtn($('#ChallengeMyself'), response.Status)
    }

    return {
        ChallengeMyselfCallback: ChallengeMyselfCallback,
        ChangeChallengeUserBtn: ChangeChallengeUserBtn
    };

})();
