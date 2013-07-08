<?php 
try
{
	$pdo_options[PDO::ATTR_ERRMODE] = PDO::ERRMODE_EXCEPTION;
    $bdd = new PDO('mysql:host=mysql51-45.perso;dbname=romainpeu1991', 'romainpeu1991', 'i667Uy36', $pdo_options);
	$tableau = "<table>";
	$req1 = $bdd->query('SELECT * FROM ExamUnity ORDER BY score DESC LIMIT 0,10');
	while ($donnees = $req1->fetch()) {
		$tableau .= "<tr>";
		$tableau .= "<td>$donnees[pseudo]</td>";
		$tableau .= "<td>$donnees[score]</td>";
		$tableau .= "</tr>";
	
	}
	$tableau .= "</table>";
	echo $tableau;


}
catch(Exception $e)
{
    die('Erreur : '.$e->getMessage());
}

?>