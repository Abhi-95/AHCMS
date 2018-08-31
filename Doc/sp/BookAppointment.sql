
Alter PROCEDURE BookAppointment
	@ID nvarchar(128),
	@DoctorID nvarchar(128),
	@PatientID nvarchar(128),
	@Date date,
	@Slot tinyint,
	@Token tinyint,
	@CreatedBy nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Appointment(AppointmentId, AppointmentDate, Slot, Token, PatientId, DoctorId, IsDeleted, CreatedOn, CreatedBy, Status)
	VALUES(@ID, @Date, @Slot, @Token, @PatientID, @DoctorID, 0, GETDATE(), @CreatedBy, 0)

	select @@ERROR
END
GO
