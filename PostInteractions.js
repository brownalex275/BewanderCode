//POST: FlagPost function



function FlagPost(ID, element) {



    var listID = "#" + ID + "post";



    var likesCount = document.getElementById(ID + " ");



$.ajax({



    type: "POST",



    url: "/Posts/FlagPost?postID=" + ID,



    error: function (html) {



        $(listID).html("").show();



        return;



    },



    success: function (html) {



        $(listID).html("").show();



        $(listID).html(html).show();



        element.setAttribute("onclick", "FlagPost('" + ID + "', this)");



        element.setAttribute("id", "flagged");



        $('#flagModal').modal('toggle');



        $('#submitModal').modal('toggle');



    }







    })



}



