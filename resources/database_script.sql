/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Answers]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[Response] [nvarchar](160) NOT NULL,
	[Question_QuestionId] [int] NOT NULL,
	[User_UserId] [int] NOT NULL,
	[AnswerType] [int] NOT NULL,
	[TimeStamp] [datetime] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Family]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[MaritalStatus] [int] NOT NULL,
	[Anniversary] [datetime] NULL,
 CONSTRAINT [PK_Family] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[FamilyMembers]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMembers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TypeId] [int] NOT NULL,
	[UserRefId] [int] NULL,
	[FamilyId] [int] NOT NULL,
 CONSTRAINT [PK_FamilyMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[FamilyMemberType]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyMemberType](
	[TypeId] [int] NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FamilyMemberType] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Gift]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gift](
	[GiftID] [int] IDENTITY(1,1) NOT NULL,
	[GiftName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Gift] PRIMARY KEY CLUSTERED 
(
	[GiftID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[GroupedMessage]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupedMessage](
	[Id] [uniqueidentifier] NOT NULL,
	[GroupedMessageName] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[TrrigeredTime] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupedMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[GroupRole]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupRole](
	[groupRoleID] [int] NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GroupRole_1] PRIMARY KEY CLUSTERED 
(
	[groupRoleID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Groups]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[GroupTags]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_GroupTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[History]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[UserId] [int] NOT NULL,
	[SalvationDate] [datetime] NULL,
	[OriginalChurch] [nvarchar](50) NULL,
	[BabtisimDate] [datetime] NULL,
	[JoiningReason] [nvarchar](max) NULL,
	[WithOfficialLetter] [bit] NOT NULL,
	[LetterReason] [nvarchar](max) NULL,
	[JoinedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Member]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Status] [int] NOT NULL CONSTRAINT [DF_Member_Status]  DEFAULT ((1)),
	[Description] [nvarchar](max) NULL,
	[CurrentSurvey] [int] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
	[OccupationID] [int] NULL,
	[IsMale] [bit] NOT NULL CONSTRAINT [DF_Member_IsMale]  DEFAULT ((0)),
	[ReferenceID] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[MemberAddress]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberAddress](
	[UserId] [int] NOT NULL,
	[Subcity] [nvarchar](50) NULL,
	[Subrub] [nvarchar](50) NULL,
	[Kebele] [nvarchar](50) NULL,
	[HouseNumber] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[WorkPhone] [nvarchar](50) NULL,
	[HomePhone] [nvarchar](50) NULL,
	[Post] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Twitter] [nvarchar](50) NULL,
 CONSTRAINT [PK_MemberAddress] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[MessageLog]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageLog](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageBody] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_MessageLog] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Messages]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[msg_body] [nvarchar](160) NOT NULL,
	[Status] [int] NOT NULL,
	[ScheduledTime] [datetime] NULL,
	[SentTime] [datetime] NULL,
	[RecievedTime] [datetime] NULL,
	[SentBy] [nvarchar](50) NULL,
	[ParentGroup] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[MessageStatus]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MessageStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Occupation]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Occupation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Occupation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[PhoneStatus]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneStatus](
	[PhoneId] [int] NOT NULL,
	[SIM_Number] [nvarchar](50) NULL,
	[PowerMode] [int] NULL,
	[LastConnected] [datetime] NULL,
	[BatteryLevel] [int] NULL,
	[Network] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhoneStatus] PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[PossibleAnswers]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PossibleAnswers](
	[PossibleAnswerID] [int] NOT NULL,
	[Value] [nvarchar](50) NULL,
 CONSTRAINT [PK_AnswerTypes] PRIMARY KEY CLUSTERED 
(
	[PossibleAnswerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[QAType]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QAType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QuestionTypes] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[QuestionPool]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionPool](
	[QuestionPoolID] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](160) NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_QuestionPool] PRIMARY KEY CLUSTERED 
(
	[QuestionPoolID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionType] [int] NOT NULL,
	[Survey_SurveyId] [int] NOT NULL,
	[Question] [nvarchar](160) NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Resolution]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resolution](
	[ResolutionID] [int] IDENTITY(1,1) NOT NULL,
	[SurveyID] [int] NULL,
	[UserId] [int] NULL,
	[message] [nvarchar](max) NULL,
	[Resolved] [bit] NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Resolution] PRIMARY KEY CLUSTERED 
(
	[ResolutionID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[ServiceCodes]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCodes](
	[ServiceCodeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NULL,
	[Service] [nvarchar](50) NULL,
	[Type] [int] NULL,
	[Response] [nvarchar](500) NOT NULL,
	[AutoReply] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ServiceCodes] PRIMARY KEY CLUSTERED 
(
	[ServiceCodeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[ServiceRequests]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRequests](
	[ServiceRequestID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceCodeID] [int] NULL,
	[RequestFromNumber] [nvarchar](50) NULL,
	[RequestTime] [datetime] NOT NULL,
	[RequestFromName] [nvarchar](50) NULL,
 CONSTRAINT [PK_ServiceRequests] PRIMARY KEY CLUSTERED 
(
	[ServiceRequestID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Surveys]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Surveys](
	[SurveyId] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Status] [int] NULL,
	[SurveyName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Surveys] PRIMARY KEY CLUSTERED 
(
	[SurveyId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[SurveyStatus]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyStatus](
	[SurveyStatusID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SurveyStatus] PRIMARY KEY CLUSTERED 
(
	[SurveyStatusID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[SurveyUsers]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyUsers](
	[Survey_SurveyId] [int] NOT NULL,
	[Users_UserId] [int] NOT NULL
)

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UserGift]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGift](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GiftID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_UserGift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[UserGroupID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UsersStatus]    Script Date: 5/9/2020 6:19:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersStatus](
	[UsersStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsersStatus] PRIMARY KEY CLUSTERED 
(
	[UsersStatusId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'viewers')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'43cf67cb-6d91-4529-8ea7-b9ad4253d859', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'43cf67cb-6d91-4529-8ea7-b9ad4253d859', N'admin', N'ADXZB04t4QgI45LWTpHsfvst+vMxU0FwkT8smvctHwvHL3MwHO9PVV5oQfclaTRMwg==', N'fef3e1be-41cf-40d6-9846-d7e16e569975', N'ApplicationUser')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (1, N'Father')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (2, N'Mother')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (3, N'Wife')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (4, N'Husband')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (5, N'Daughter')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (6, N'Son')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (7, N'Brother')
INSERT [dbo].[FamilyMemberType] ([TypeId], [TypeName]) VALUES (8, N'Sister')
SET IDENTITY_INSERT [dbo].[Gift] ON 

INSERT [dbo].[Gift] ([GiftID], [GiftName]) VALUES (1016, N'Choir')
INSERT [dbo].[Gift] ([GiftID], [GiftName]) VALUES (1017, N'IT')
INSERT [dbo].[Gift] ([GiftID], [GiftName]) VALUES (1018, N'Teaching')
INSERT [dbo].[Gift] ([GiftID], [GiftName]) VALUES (1019, N'Youth')
SET IDENTITY_INSERT [dbo].[Gift] OFF
INSERT [dbo].[GroupRole] ([groupRoleID], [Role]) VALUES (1, N'Leader')
INSERT [dbo].[GroupRole] ([groupRoleID], [Role]) VALUES (2, N'Member')
SET IDENTITY_INSERT [dbo].[GroupTags] ON 

INSERT [dbo].[GroupTags] ([Id], [TagID], [GroupID]) VALUES (1, 2, 1)
INSERT [dbo].[GroupTags] ([Id], [TagID], [GroupID]) VALUES (2, 1010, 1)
SET IDENTITY_INSERT [dbo].[GroupTags] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([UserId], [Name], [LastName], [MiddleName], [PhoneNumber], [Status], [Description], [CurrentSurvey], [ImagePath], [BirthDate], [OccupationID], [IsMale], [ReferenceID]) VALUES (1, N'Robel', N'Herarso', N'Tessema', N'+251935933263', 1, NULL, NULL, NULL, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[MessageStatus] ON 

INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (2, N'Delivered')
INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (3, N'Failed')
INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (4, N'Needs Resolution')
INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (5, N'Scheduled')
INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (6, N'Recieved')
INSERT [dbo].[MessageStatus] ([StatusID], [Description]) VALUES (7, N'Pending')
SET IDENTITY_INSERT [dbo].[MessageStatus] OFF
SET IDENTITY_INSERT [dbo].[Occupation] ON 

INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (1, N'Student')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (2, N'Engineer')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (3, N'Doctor')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (4, N'Governmental Worker')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (24, N'Dentist')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (1030, N'Fashion Designer')
INSERT [dbo].[Occupation] ([Id], [Title]) VALUES (1031, N'Private')
SET IDENTITY_INSERT [dbo].[Occupation] OFF
INSERT [dbo].[PhoneStatus] ([PhoneId], [SIM_Number], [PowerMode], [LastConnected], [BatteryLevel], [Network]) VALUES (1, N'0930293918', 0, CAST(N'2016-01-01 07:50:01.787' AS DateTime), 66, N'WIFI')
INSERT [dbo].[PossibleAnswers] ([PossibleAnswerID], [Value]) VALUES (1, N'Yes')
INSERT [dbo].[PossibleAnswers] ([PossibleAnswerID], [Value]) VALUES (2, N'No')
INSERT [dbo].[PossibleAnswers] ([PossibleAnswerID], [Value]) VALUES (3, N'Quantitative')
SET IDENTITY_INSERT [dbo].[QAType] ON 

INSERT [dbo].[QAType] ([TypeId], [Description]) VALUES (1, N'Yes or No')
INSERT [dbo].[QAType] ([TypeId], [Description]) VALUES (2, N'Quantitative')
SET IDENTITY_INSERT [dbo].[QAType] OFF
SET IDENTITY_INSERT [dbo].[ServiceCodes] ON 

INSERT [dbo].[ServiceCodes] ([ServiceCodeID], [Code], [Service], [Type], [Response], [AutoReply], [Active]) VALUES (1, N'JOIN', N'Registration', 1, N'Welcome to City Of Refugee Church. You have successfully subscribed to our SMS ministry. God bless you.', 1, 1)
INSERT [dbo].[ServiceCodes] ([ServiceCodeID], [Code], [Service], [Type], [Response], [AutoReply], [Active]) VALUES (2, N'P', N'Prayer Request', 1, N'Your prayer request is received. We will be praying for you.  ', 1, 1)
INSERT [dbo].[ServiceCodes] ([ServiceCodeID], [Code], [Service], [Type], [Response], [AutoReply], [Active]) VALUES (3, N'C', N'Comment', 1, N'We are glad to receive a comment from you. We will look in  to your comment and take the proper action.', 1, 1)
SET IDENTITY_INSERT [dbo].[ServiceCodes] OFF
SET IDENTITY_INSERT [dbo].[SurveyStatus] ON 

INSERT [dbo].[SurveyStatus] ([SurveyStatusID], [Description]) VALUES (1, N'Active')
INSERT [dbo].[SurveyStatus] ([SurveyStatusID], [Description]) VALUES (2, N'Completed')
INSERT [dbo].[SurveyStatus] ([SurveyStatusID], [Description]) VALUES (3, N'Draft')
INSERT [dbo].[SurveyStatus] ([SurveyStatusID], [Description]) VALUES (4, N'Paused')
SET IDENTITY_INSERT [dbo].[SurveyStatus] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (1, N'Prayer Ministry')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (2, N'Choir Ministry')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (3, N'Visitation')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (4, N'Women Ministry')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (5, N'Family Counseling')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (6, N'Youth Minsitry')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (7, N'Compassion Ministry')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (1008, N'New Converts')
INSERT [dbo].[Tags] ([TagId], [TagName]) VALUES (1010, N'#YOF')
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET IDENTITY_INSERT [dbo].[UserGift] ON 

INSERT [dbo].[UserGift] ([Id], [GiftID], [UserID]) VALUES (1, 1016, 1)
SET IDENTITY_INSERT [dbo].[UserGift] OFF
SET IDENTITY_INSERT [dbo].[UsersStatus] ON 

INSERT [dbo].[UsersStatus] ([UsersStatusId], [Description]) VALUES (1, N'Approved')
INSERT [dbo].[UsersStatus] ([UsersStatusId], [Description]) VALUES (2, N'Disabled')
INSERT [dbo].[UsersStatus] ([UsersStatusId], [Description]) VALUES (3, N'Requested')
SET IDENTITY_INSERT [dbo].[UsersStatus] OFF
/****** Object:  Index [PK_SurveyUsers]    Script Date: 5/9/2020 6:19:48 PM ******/
ALTER TABLE [dbo].[SurveyUsers] ADD  CONSTRAINT [PK_SurveyUsers] PRIMARY KEY NONCLUSTERED 
(
	[Survey_SurveyId] ASC,
	[Users_UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[Resolution] ADD  CONSTRAINT [DF_Resolution_Resolved]  DEFAULT ((0)) FOR [Resolved]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Member] FOREIGN KEY([User_UserId])
REFERENCES [dbo].[Member] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Member]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_PossibleAnswers] FOREIGN KEY([AnswerType])
REFERENCES [dbo].[PossibleAnswers] ([PossibleAnswerID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_PossibleAnswers]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAnswer] FOREIGN KEY([Question_QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_QuestionAnswer]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Family]  WITH CHECK ADD  CONSTRAINT [FK_Family_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Member] ([UserId])
GO
ALTER TABLE [dbo].[Family] CHECK CONSTRAINT [FK_Family_Users]
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD  CONSTRAINT [FK_FamilyMembers_Family] FOREIGN KEY([FamilyId])
REFERENCES [dbo].[Family] ([UserId])
GO
ALTER TABLE [dbo].[FamilyMembers] CHECK CONSTRAINT [FK_FamilyMembers_Family]
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD  CONSTRAINT [FK_FamilyMembers_FamilyMemberType1] FOREIGN KEY([TypeId])
REFERENCES [dbo].[FamilyMemberType] ([TypeId])
GO
ALTER TABLE [dbo].[FamilyMembers] CHECK CONSTRAINT [FK_FamilyMembers_FamilyMemberType1]
GO
ALTER TABLE [dbo].[FamilyMembers]  WITH CHECK ADD  CONSTRAINT [FK_FamilyMembers_Users] FOREIGN KEY([UserRefId])
REFERENCES [dbo].[Member] ([UserId])
GO
ALTER TABLE [dbo].[FamilyMembers] CHECK CONSTRAINT [FK_FamilyMembers_Users]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Member] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Users]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Occupation] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[Occupation] ([Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Occupation]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Users_Surveys] FOREIGN KEY([CurrentSurvey])
REFERENCES [dbo].[Surveys] ([SurveyId])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Users_Surveys]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Users_UsersStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[UsersStatus] ([UsersStatusId])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Users_UsersStatus]
GO
ALTER TABLE [dbo].[MemberAddress]  WITH CHECK ADD  CONSTRAINT [FK_MemberAddress_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Member] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberAddress] CHECK CONSTRAINT [FK_MemberAddress_Users]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_GroupedMessage] FOREIGN KEY([ParentGroup])
REFERENCES [dbo].[GroupedMessage] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_GroupedMessage]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_MessageStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[MessageStatus] ([StatusID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_MessageStatus]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Member] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Users]
GO
ALTER TABLE [dbo].[QuestionPool]  WITH CHECK ADD  CONSTRAINT [FK_QuestionPool_QAType] FOREIGN KEY([Type])
REFERENCES [dbo].[QAType] ([TypeId])
GO
ALTER TABLE [dbo].[QuestionPool] CHECK CONSTRAINT [FK_QuestionPool_QAType]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_QAType] FOREIGN KEY([QuestionType])
REFERENCES [dbo].[QAType] ([TypeId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_QAType]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_SurveyQuestion] FOREIGN KEY([Survey_SurveyId])
REFERENCES [dbo].[Surveys] ([SurveyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_SurveyQuestion]
GO
ALTER TABLE [dbo].[Resolution]  WITH CHECK ADD  CONSTRAINT [FK_Resolution_Surveys] FOREIGN KEY([SurveyID])
REFERENCES [dbo].[Surveys] ([SurveyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Resolution] CHECK CONSTRAINT [FK_Resolution_Surveys]
GO
ALTER TABLE [dbo].[Resolution]  WITH CHECK ADD  CONSTRAINT [FK_Resolution_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Member] ([UserId])
GO
ALTER TABLE [dbo].[Resolution] CHECK CONSTRAINT [FK_Resolution_Users]
GO
ALTER TABLE [dbo].[ServiceRequests]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequests_ServiceCodes] FOREIGN KEY([ServiceCodeID])
REFERENCES [dbo].[ServiceCodes] ([ServiceCodeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceRequests] CHECK CONSTRAINT [FK_ServiceRequests_ServiceCodes]
GO
ALTER TABLE [dbo].[Surveys]  WITH CHECK ADD  CONSTRAINT [FK_Surveys_SurveyStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[SurveyStatus] ([SurveyStatusID])
GO
ALTER TABLE [dbo].[Surveys] CHECK CONSTRAINT [FK_Surveys_SurveyStatus]
GO
ALTER TABLE [dbo].[SurveyUsers]  WITH CHECK ADD  CONSTRAINT [FK_SurveyUsers_Survey] FOREIGN KEY([Survey_SurveyId])
REFERENCES [dbo].[Surveys] ([SurveyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurveyUsers] CHECK CONSTRAINT [FK_SurveyUsers_Survey]
GO
ALTER TABLE [dbo].[SurveyUsers]  WITH CHECK ADD  CONSTRAINT [FK_SurveyUsers_Users] FOREIGN KEY([Users_UserId])
REFERENCES [dbo].[Member] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SurveyUsers] CHECK CONSTRAINT [FK_SurveyUsers_Users]
GO
ALTER TABLE [dbo].[UserGift]  WITH CHECK ADD  CONSTRAINT [FK_UserGift_Gift] FOREIGN KEY([GiftID])
REFERENCES [dbo].[Gift] ([GiftID])
GO
ALTER TABLE [dbo].[UserGift] CHECK CONSTRAINT [FK_UserGift_Gift]
GO
ALTER TABLE [dbo].[UserGift]  WITH CHECK ADD  CONSTRAINT [FK_UserGift_Member1] FOREIGN KEY([UserID])
REFERENCES [dbo].[Member] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGift] CHECK CONSTRAINT [FK_UserGift_Member1]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_GroupRole1] FOREIGN KEY([RoleID])
REFERENCES [dbo].[GroupRole] ([groupRoleID])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_GroupRole1]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Groups]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Member] ([UserId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserGroups_Users]
GO
