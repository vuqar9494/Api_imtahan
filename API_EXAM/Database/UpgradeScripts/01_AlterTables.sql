--liquibase formatted sql


USE [API_EXAM]
GO

ALTER TABLE [dbo].[USER_COURSE_CON]
   ADD 
      IS_COMPLETED bit,
      COMPLETED_ON  datetime2(7)
GO


ALTER TABLE [dbo].[COURSE]
   ADD 
      EDITION_DATE  datetime2(7)