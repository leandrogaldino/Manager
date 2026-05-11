SELECT
	evaluationpicture.id,
	evaluationpicture.creation,
	evaluationpicture.evaluationid,
	evaluationpicture.picturename
FROM evaluationpicture
WHERE evaluationpicture.evaluationid = @evaluationid;