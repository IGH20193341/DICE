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


$sql = "SELECT * FROM sw_db.user WHERE user_id = '".$user_id."' ";
$result = mysqli_query($conn, $sql);

if(mysqli_num_rows($result)==0)
{
  $sql = "INSERT INTO user (user_id, user_pw, coin) VALUES ('".$user_id."', '".$user_pw."', 0);";
  $result = mysqli_query($conn, $sql);
  if($result)
	die("Create Success.\n");
  else
	die("Create error.\n");  

} else {
    die("ID does exist. \n");
  }

?>