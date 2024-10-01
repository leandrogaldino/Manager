SELECT
	evaluationpart.id,
	evaluationpart.creation,
	evaluationpart.personcompressorid,
	evaluationpart.personcompressorpartid,
	evaluationpart.currentcapacity,
	evaluationpart.sold,
	evaluationpart.lost,
	evaluationpart.userid
FROM evaluationpart
LEFT JOIN personcompressorpart ON personcompressorpart.id = evaluationpart.personcompressorpartid
WHERE 
	evaluationpart.evaluationid = @evaluationid AND
	personcompressorpart.parttypeid = @parttypeid;