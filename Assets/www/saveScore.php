<?php 
try
{
    $pdo_options[PDO::ATTR_ERRMODE] = PDO::ERRMODE_EXCEPTION;
    $bdd = new PDO('mysql:host=mysql51-45.perso;dbname=romainpeu1991', 'romainpeu1991', 'i667Uy36', $pdo_options);
	
	$req1 = $bdd->prepare('SELECT * FROM ExamUnity WHERE pseudo = :pseudo');
	$req1->execute(array(
		'pseudo' => htmlspecialchars($_GET["pseudo"])
	));
	$donnees = $req1->fetch();
	if (!$donnees) {
		$req2 = $bdd->prepare('INSERT INTO ExamUnity(pseudo, score) VALUES(:pseudo, :score)');
		if($_GET["pseudo"] != ""){
			$req2->execute(array(
				'pseudo' => htmlspecialchars($_GET["pseudo"]),
				'score' => htmlspecialchars($_GET["score"])
			));
		}
	} else {
		
		if ($donnees['score'] < $_GET['score']) {
			$req3 = $bdd->prepare('UPDATE ExamUnity SET score = :score WHERE pseudo = :pseudo');
			if($_GET["pseudo"] != ""){
				$req3->execute(array(
					'score' => htmlspecialchars($_GET["score"]),
					'pseudo' => htmlspecialchars($_GET["pseudo"])
				));
			}
		}
	}
	
	

    
}
catch(Exception $e)
{
    die('Erreur : '.$e->getMessage());
}
?>