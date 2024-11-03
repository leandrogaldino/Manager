SELECT
	evaluationphoto.id,
	evaluationphoto.creation,
	evaluationphoto.evaluationid,
	evaluationphoto.photoname
FROM evaluationphoto
WHERE evaluationphoto.evaluationid = @evaluationid;