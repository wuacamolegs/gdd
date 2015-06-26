
-- IDENTIFICA QUE SESION (blocking_session_id) ESTA BLOQUEANDO A QUIEN (session_id)

SELECT blocking_session_id, wait_duration_ms, session_id
FROM sys.dm_os_waiting_tasks      
WHERE blocking_session_id IS NOT NULL


-- REEMPLAZAS EN WHERE c.session_id = X siendo X el blocking_session_id que te dio antes
-- ACA TE DICE EN QUE PARTE DE LA BD ESTA BLOQUEANDO

SELECT t.text
FROM sys.dm_exec_connections c
CROSS APPLY sys.dm_exec_sql_text (c.most_recent_sql_handle) t
WHERE c.session_id = 57


--NO ENTENDI QUE HACE
SELECT request_session_id sessionid,
 resource_type type,
 resource_database_id dbid,
 OBJECT_NAME(resource_associated_entity_id, resource_database_id) objectname,
 request_mode rmode,
 request_status rstatus
FROM sys.dm_tran_locks
WHERE resource_type IN ('DATABASE', 'OBJECT', 'TABLE')