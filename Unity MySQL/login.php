<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "sw_db";

$conn = mysqli_connect($servername, $username, $password, $dbname);

if(!$conn){
  die("Connection Failed.". mysqli_connect_error());
}
else echo ("Connection Success");



$user_id = $_POST["Input_user"];
$user_pw = $_POST["Input_pass"];


$sql = "SELECT * FROM user WHERE user_id = '".$user_id."' ";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result)>0)
{
  while ($row = mysqli_fetch_assoc($result)) {
    if($row['user_pw'] == $user_pw)
    {
      echo "login success";
    }else {
      echo "password incorrect";
      echo "password is = ".$row['user_pw'];
    }
  }
} else {
    echo "user not found";
    echo "password is = ".$row['user_pw'];
  }

?>