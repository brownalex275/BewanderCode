function FlagNotification(ID, element) {



    var listID = "#" + ID + "post";



    $.ajax({



        type: "POST",
      url: "/Notifications/FlagNotification?postID=" + ID,



        error: function (html) {



            $(listID).html("").show();



            return;



        },



        success: function (html) {
          url: "/Notifications/FlagNotification?postID=" + ID,



        error: function (html) {



            $(listID).html("").show();



            return;



        },



        success: function (html) {$(listID).html("").show();



            $(listID).html(html).show();



          



        }







    });