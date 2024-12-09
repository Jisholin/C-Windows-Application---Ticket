IF EXISTS (SELECT * FROM sys.change_tracking_tables WHERE object_id = OBJECT_ID(N'[dbo].[Ticket_Form]')) 
   ALTER TABLE [dbo].[Ticket_Form] 
   DISABLE  CHANGE_TRACKING
GO
