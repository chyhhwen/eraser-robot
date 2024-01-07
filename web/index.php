<?php
    include "plugins.php";
    if(@p('s'))
    {
        echo'
        <html>
            <head>
            <meta name="viewport" content="width=device-width,initia    l-scale=1.0">
            <title>檔案上傳</title>
            </head>
            <body>
                <style>
                    body
                    {
                        margin:10%;
                        background-image: url(\'02.jpg\');
                        background-size:500px,800px;
                    } 
                </style>
                <body>
        ';   
        if($_FILES["fileUpload"]["error"]==0)
        {
            if(move_uploaded_file($_FILES["fileUpload"]["tmp_name"],
            "./".$_FILES["fileUpload"]["name"]))
            {
                echo '<h1>上傳成功<h1>';
                $n=$_FILES["fileUpload"]["name"];
                $d=$_FILES["fileUpload"]["type"];
                $k=k(time());
                squery(['run',"INSERT INTO input VALUES('','$k','$n','$d','$time')"]);
            }
            else
            {
                echo '<h1>上傳失敗<h1>';
            }
        }
        ref([1,"index.php"]);
        echo'</body>
            </html>';
    }
    else
    {
        echo '
            <html>
            <head>
            <meta name="viewport" content="width=device-width,initial-scale=1.0">
            <title>檔案上傳</title>
            </head>
            <body>
                <style>
                    body
                    {
                        margin:10%;
                        background-image: url(\'01.jpg\');
                        background-size:500px,800px;
                    }      
                    .box
                    {
                        width:100vw;
                        height:100Vh;
                        display:flex;
                        flex-wrap:wrap;
                    }     
                    .file
                    {
                        width:100%;
                        height:5%;
                    }
                </style>
                <form action="" method="post" enctype="multipart/form-data">
                    <div class"box">
                        <div class="file">
                            <input type="file" name="fileUpload">
                        </div>
                        <div class="submit">
                            <input type="submit" name="s" value="送出">
                        </div>
                    </div>
                </form>
            </body>
            </html>
        ';
    }
?>