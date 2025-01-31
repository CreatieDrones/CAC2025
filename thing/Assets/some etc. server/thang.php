<?php
$servername = "http://192.168.1.166:8080/phpmyadmin";
$username = "phpmyadmin"; // or your database username
$password = "root";  // or your database password
$dbname = "CAC"; // your database name

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Example: Retrieve data
$sql = "SELECT * FROM users";
$result = $conn->query($sql);

$data = array();
if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        $data[] = $row; // store results in an array
    }
}

// Output data as JSON
echo json_encode($data);

$conn->close();
?>
