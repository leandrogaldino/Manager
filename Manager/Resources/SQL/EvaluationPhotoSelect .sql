SELECT
	evaluationphoto.id,
	evaluationphoto.creation,
	evaluationphoto.evaluationid,
	evaluationphoto.photopath
FROM evaluationphoto
WHERE evaluationphoto.evaluationid = @evaluationid;