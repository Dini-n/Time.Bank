use TimeBank
go
ALTER TABLE members
ADD UNIQUE (phone);
use TimeBank
go

ALTER TABLE ReportsDetails
ADD UNIQUE (getterMemberId,reportId);
ALTER TABLE memberCategory
ADD UNIQUE (memberId,categoryId);