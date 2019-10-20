﻿using System;
using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>
		/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
		/// directory opened.
		/// </para>
		/// <para>
		/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next change
		/// (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
		/// </para>
		/// <para>
		/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
		/// records a new parent.
		/// </para>
		/// </summary>
		[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
		[Flags]
		public enum USN_REASON : uint
		{
			/// <summary>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </summary>
			USN_REASON_BASIC_INFO_CHANGE = 0x00008000,

			/// <summary>The file or directory is closed.</summary>
			USN_REASON_CLOSE = 0x80000000,

			/// <summary>The compression state of the file or directory is changed from or to compressed.</summary>
			USN_REASON_COMPRESSION_CHANGE = 0x00020000,

			/// <summary>The file or directory is extended (added to).</summary>
			USN_REASON_DATA_EXTEND = 0x00000002,

			/// <summary>The data in the file or directory is overwritten.</summary>
			USN_REASON_DATA_OVERWRITE = 0x00000001,

			/// <summary>The file or directory is truncated.</summary>
			USN_REASON_DATA_TRUNCATION = 0x00000004,

			/// <summary>
			/// The user made a change to the extended attributes of a file or directory.
			/// <para>These NTFS file system attributes are not accessible to Windows-based applications.</para>
			/// </summary>
			USN_REASON_EA_CHANGE = 0x00000400,

			/// <summary>The file or directory is encrypted or decrypted.</summary>
			USN_REASON_ENCRYPTION_CHANGE = 0x00040000,

			/// <summary>The file or directory is created for the first time.</summary>
			USN_REASON_FILE_CREATE = 0x00000100,

			/// <summary>The file or directory is deleted.</summary>
			USN_REASON_FILE_DELETE = 0x00000200,

			/// <summary>
			/// An NTFS file system hard link is added to or removed from the file or directory.
			/// <para>
			/// An NTFS file system hard link, similar to a POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </para>
			/// </summary>
			USN_REASON_HARD_LINK_CHANGE = 0x00010000,

			/// <summary>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute.
			/// <para>
			/// That is, the user changes the file or directory from one where content can be indexed to one where content cannot be indexed,
			/// or vice versa. Content indexing permits rapid searching of data by building a database of selected content.
			/// </para>
			/// </summary>
			USN_REASON_INDEXABLE_CHANGE = 0x00004000,

			/// <summary>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream.
			/// <para>
			/// On the ReFS file system, integrity streams maintain a checksum of all data for that stream, so that the contents of the file
			/// can be validated during read or write operations.
			/// </para>
			/// </summary>
			USN_REASON_INTEGRITY_CHANGE = 0x00800000,

			/// <summary>The one or more named data streams for a file are extended (added to).</summary>
			USN_REASON_NAMED_DATA_EXTEND = 0x00000020,

			/// <summary>The data in one or more named data streams for a file is overwritten.</summary>
			USN_REASON_NAMED_DATA_OVERWRITE = 0x00000010,

			/// <summary>The one or more named data streams for a file is truncated.</summary>
			USN_REASON_NAMED_DATA_TRUNCATION = 0x00000040,

			/// <summary>The object identifier of a file or directory is changed.</summary>
			USN_REASON_OBJECT_ID_CHANGE = 0x00080000,

			/// <summary>A file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the new name.</summary>
			USN_REASON_RENAME_NEW_NAME = 0x00002000,

			/// <summary>The file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the previous name.</summary>
			USN_REASON_RENAME_OLD_NAME = 0x00001000,

			/// <summary>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </summary>
			USN_REASON_REPARSE_POINT_CHANGE = 0x00100000,

			/// <summary>A change is made in the access rights to a file or directory.</summary>
			USN_REASON_SECURITY_CHANGE = 0x00000800,

			/// <summary>A named stream is added to or removed from a file, or a named stream is renamed.</summary>
			USN_REASON_STREAM_CHANGE = 0x00200000,

			/// <summary>The given stream is modified through a TxF transaction.</summary>
			USN_REASON_TRANSACTED_CHANGE = 0x00400000,
		}

		/// <summary>
		/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
		/// <para>
		/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
		/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that are
		/// set only by a known source, for example, an antivirus filter.
		/// </para>
		/// </summary>
		[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
		[Flags]
		public enum USN_SOURCE
		{
			/// <summary>
			/// The operation adds a private data stream to a file or directory.
			/// <para>
			/// An example might be a virus detector adding checksum information. As the virus detector modifies the item, the system
			/// generates USN records. USN_SOURCE_AUXILIARY_DATA indicates that the modifications did not change the application data.
			/// </para>
			/// </summary>
			USN_SOURCE_AUXILIARY_DATA = 0x00000002,

			/// <summary>
			/// The operation provides information about a change to the file or directory made by the operating system.
			/// <para>
			/// A typical use is when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical
			/// storage management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record.
			/// However, the data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo
			/// member, you can determine that although a write operation is performed on the item, data has not changed.
			/// </para>
			/// </summary>
			USN_SOURCE_DATA_MANAGEMENT = 0x00000001,

			/// <summary>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </summary>
			USN_SOURCE_REPLICATION_MANAGEMENT = 0x00000004,

			/// <summary>
			/// The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.
			/// </summary>
			USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT = 0x00000008,
		}

		/// <summary>Contains the output for the FSCTL_GET_BOOT_AREA_INFO control code.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-boot_area_info typedef struct _BOOT_AREA_INFO { DWORD
		// BootSectorCount; struct { LARGE_INTEGER Offset; } BootSectors[2]; } BOOT_AREA_INFO, *PBOOT_AREA_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "e6ec156d-6a20-4b00-89fb-a27421fffbc0")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BOOT_AREA_INFO
		{
			/// <summary>Number of elements in the <c>BootSectors</c> array.</summary>
			public uint BootSectorCount;

			/// <summary>
			/// <para>A variable length array of structures each containing the following member.</para>
			/// <para>Offset</para>
			/// <para>The location of a boot sector or a copy of a boot sector.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public long[] BootSectors;
		}

		/// <summary>Represents a changer element.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element typedef struct _CHANGER_ELEMENT {
		// ELEMENT_TYPE ElementType; DWORD ElementAddress; } CHANGER_ELEMENT, *PCHANGER_ELEMENT;
		[PInvokeData("winioctl.h", MSDNShortId = "96e9803b-16c4-415c-940a-f5df3edff3b3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CHANGER_ELEMENT
		{
			/// <summary>The element type. This parameter can be one of the values from the ELEMENT_TYPE enumeration type.</summary>
			public ELEMENT_TYPE ElementType;

			/// <summary>The zero-based address of the element.</summary>
			public uint ElementAddress;
		}

		/// <summary>
		/// Represents a range of elements of a single type, typically for an operation such as getting or initializing the status of
		/// multiple elements.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element_list typedef struct _CHANGER_ELEMENT_LIST
		// { CHANGER_ELEMENT Element; DWORD NumberOfElements; } CHANGER_ELEMENT_LIST, *PCHANGER_ELEMENT_LIST;
		[PInvokeData("winioctl.h", MSDNShortId = "cb1fcf78-b36a-4551-8eeb-da58edc80890")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CHANGER_ELEMENT_LIST
		{
			/// <summary>A CHANGER_ELEMENT structure that represent the first element in the range.</summary>
			public CHANGER_ELEMENT Element;

			/// <summary>The number of elements in the range.</summary>
			public uint NumberOfElements;
		}

		/// <summary>
		/// Contains information defining the boundaries for and starting place of an enumeration of update sequence number (USN) change
		/// journal records. It is used as the input buffer for the FSCTL_ENUM_USN_DATA control code. Prior to Windows Server 2012 this
		/// structure was named <c>MFT_ENUM_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-mft_enum_data_v0 typedef struct { DWORDLONG
		// StartFileReferenceNumber; USN LowUsn; USN HighUsn; } MFT_ENUM_DATA_V0, *PMFT_ENUM_DATA_V0;
		[PInvokeData("winioctl.h", MSDNShortId = "bd098d10-b30f-44b0-a379-2d57e33fe1c9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MFT_ENUM_DATA_V0
		{
			/// <summary>
			/// <para>The ordinal position within the files on the current volume at which the enumeration is to begin.</para>
			/// <para>
			/// The first call to FSCTL_ENUM_USN_DATA during an enumeration must have the <c>StartFileReferenceNumber</c> member set to .
			/// Each call to <c>FSCTL_ENUM_USN_DATA</c> retrieves the starting point for the subsequent call as the first entry in the output
			/// buffer. Subsequent calls must be made with <c>StartFileReferenceNumber</c> set to this value. For more information, see <c>FSCTL_ENUM_USN_DATA</c>.
			/// </para>
			/// </summary>
			public ulong StartFileReferenceNumber;

			/// <summary>
			/// The lower boundary of the range of USN values used to filter which records are returned. Only records whose last change
			/// journal USN is between or equal to the <c>LowUsn</c> and <c>HighUsn</c> member values are returned.
			/// </summary>
			public long LowUsn;

			/// <summary>The upper boundary of the range of USN values used to filter which files are returned.</summary>
			public long HighUsn;
		}

		/// <summary>
		/// Contains information defining the boundaries for and starting place of an enumeration of update sequence number (USN) change
		/// journal records for ReFS volumes. It is used as the input buffer for the FSCTL_ENUM_USN_DATA control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-mft_enum_data_v1 typedef struct { DWORDLONG
		// StartFileReferenceNumber; USN LowUsn; USN HighUsn; WORD MinMajorVersion; WORD MaxMajorVersion; } MFT_ENUM_DATA_V1, *PMFT_ENUM_DATA_V1;
		[PInvokeData("winioctl.h", MSDNShortId = "6d7b50e3-60cf-4eaf-9d22-fbb20c7e0bba")]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct MFT_ENUM_DATA_V1
		{
			/// <summary>
			/// <para>The ordinal position within the files on the current volume at which the enumeration is to begin.</para>
			/// <para>
			/// The first call to FSCTL_ENUM_USN_DATA during an enumeration must have the <c>StartFileReferenceNumber</c> member set to .
			/// Each call to <c>FSCTL_ENUM_USN_DATA</c> retrieves the starting point for the subsequent call as the first entry in the output
			/// buffer. Subsequent calls must be made with <c>StartFileReferenceNumber</c> set to this value. For more information, see <c>FSCTL_ENUM_USN_DATA</c>.
			/// </para>
			/// </summary>
			public ulong StartFileReferenceNumber;

			/// <summary>
			/// The lower boundary of the range of USN values used to filter which records are returned. Only records whose last change
			/// journal USN is between or equal to the <c>LowUsn</c> and <c>HighUsn</c> member values are returned.
			/// </summary>
			public long LowUsn;

			/// <summary>The upper boundary of the range of USN values used to filter which files are returned.</summary>
			public long HighUsn;

			/// <summary>Indicates the minimum supported major version for the USN change journal.</summary>
			public ushort MinMajorVersion;

			/// <summary>
			/// <para>Indicates the maximum supported major version for the USN change journal.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The data returned from the FSCTL_ENUM_USN_DATA control code will contain USN_RECORD_V2 structures.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The data returned from the FSCTL_ENUM_USN_DATA control code will contain USN_RECORD_V2 or USN_RECORD_V3 structures.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MaxMajorVersion;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v0 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; }
		// USN_JOURNAL_DATA_V0, *PUSN_JOURNAL_DATA_V0;
		[PInvokeData("winioctl.h", MSDNShortId = "6b75eab2-aa10-4b48-8918-e4b03b5d8564")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V0
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v1 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; WORD
		// MinSupportedMajorVersion; WORD MaxSupportedMajorVersion; } USN_JOURNAL_DATA_V1, *PUSN_JOURNAL_DATA_V1;
		[PInvokeData("winioctl.h", MSDNShortId = "6b75eab2-aa10-4b48-8918-e4b03b5d8564")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V1
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;

			/// <summary/>
			public ushort MinSupportedMajorVersion;

			/// <summary/>
			public ushort MaxSupportedMajorVersion;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v2 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; WORD
		// MinSupportedMajorVersion; WORD MaxSupportedMajorVersion; DWORD Flags; DWORDLONG RangeTrackChunkSize; LONGLONG
		// RangeTrackFileSizeThreshold; } USN_JOURNAL_DATA_V2, *PUSN_JOURNAL_DATA_V2;
		[PInvokeData("winioctl.h", MSDNShortId = "BBFA6D14-1423-45B0-83A0-62019D08507F")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V2
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public long MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;

			/// <summary>The minimum version of the USN change journal that the file system supports.</summary>
			public ushort MinSupportedMajorVersion;

			/// <summary>The maximum version of the USN change journal that the file system supports.</summary>
			public ushort MaxSupportedMajorVersion;

			/// <summary>
			/// <para>Whether or not range tracking is turned on. The following are the possible values for the <c>Flags</c> member.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00000000</term>
			/// <term>Range tracking is not turned on for the volume.</term>
			/// </item>
			/// <item>
			/// <term>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE 0x00000001</term>
			/// <term>Range tracking is turned on for the volume.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>The granularity of tracked ranges. Valid only when you also set the <c>Flags</c> member to <c>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE</c>.</summary>
			public ulong RangeTrackChunkSize;

			/// <summary>
			/// File size threshold to start tracking range for files with equal or larger size. Valid only when you also set the
			/// <c>Flags</c> member to <c>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE</c>.
			/// </summary>
			public long RangeTrackFileSizeThreshold;
		}

		/// <summary>Contains returned update sequence number (USN) from FSCTL_USN_TRACK_MODIFIED_RANGES control code.</summary>
		/// <remarks>This structure is optional.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_range_track_output typedef struct { USN Usn; }
		// USN_RANGE_TRACK_OUTPUT, *PUSN_RANGE_TRACK_OUTPUT;
		[PInvokeData("winioctl.h", MSDNShortId = "E10ECB50-A506-4836-81D2-3073FBB844CA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RANGE_TRACK_OUTPUT
		{
			/// <summary>
			/// Returned update sequence number (USN) that identifies at what point in the USN Journal that range tracking was enabled.
			/// </summary>
			public long Usn;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) common header which is common through USN_RECORD_V2, USN_RECORD_V3
		/// and USN_RECORD_V4.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_common_header typedef struct { DWORD
		// RecordLength; WORD MajorVersion; WORD MinorVersion; } USN_RECORD_COMMON_HEADER, *PUSN_RECORD_COMMON_HEADER;
		[PInvokeData("winioctl.h", MSDNShortId = "7B193D8E-FEED-4289-B40F-33BC27889F15")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RECORD_COMMON_HEADER
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because USN record is a variable size, the <c>RecordLength</c> member should be used when calculating the address of the next
			/// record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl function that work
			/// with different USN record types.
			/// </para>
			/// <para>
			/// For USN_RECORD_V4, the size in bytes of any change journal record is at most the size of the structure, plus
			/// (NumberOfExtents-1) times size of the USN_RECORD_EXTENT.
			/// </para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 4.0, the major version number is 4.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 4.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;
		}

		/// <summary>Contains the offset and length for an update sequence number (USN) record extent.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_extent typedef struct { LONGLONG Offset;
		// LONGLONG Length; } USN_RECORD_EXTENT, *PUSN_RECORD_EXTENT;
		[PInvokeData("winioctl.h", MSDNShortId = "7D569FCB-06D4-4348-B75A-D087D1D37851")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RECORD_EXTENT
		{
			/// <summary>The offset of the extent, in bytes.</summary>
			public long Offset;

			/// <summary>The length of the extent, in bytes.</summary>
			public long Length;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 2.0 record. Applications should not attempt
		/// to work with change journal versions earlier than 2.0. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_RECORD</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		/// <remarks>
		/// <para>
		/// In output buffers returned from DeviceIoControl operations that work with <c>USN_RECORD_V2</c>, all records are aligned on 64-bit
		/// boundaries from the start of the buffer.
		/// </para>
		/// <para>
		/// To provide a path for upward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V2</c> structure. Your code should examine these values, detect its own
		/// compatibility with the change journal software, and if necessary gracefully handle any incompatibility.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V2</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, this makes the C code unreliable. Instead, rely on run-time calculations by using the
		/// <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V2</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, it should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v2 typedef struct { DWORD RecordLength; WORD
		// MajorVersion; WORD MinorVersion; DWORDLONG FileReferenceNumber; DWORDLONG ParentFileReferenceNumber; USN Usn; LARGE_INTEGER
		// TimeStamp; DWORD Reason; DWORD SourceInfo; DWORD SecurityId; DWORD FileAttributes; WORD FileNameLength; WORD FileNameOffset; WCHAR
		// FileName[1]; } USN_RECORD_V2, *PUSN_RECORD_V2;
		[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct USN_RECORD_V2
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because <c>USN_RECORD_V2</c> is a variable size, the <c>RecordLength</c> member should be used when calculating the address
			/// of the next record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl
			/// function that work with <c>USN_RECORD_V2</c>.
			/// </para>
			/// <para>
			/// The size in bytes of any change journal record is at most the size of the <c>USN_RECORD_V2</c> structure, plus
			/// MaximumComponentLength characters minus 1 (for the character declared in the structure) times the size of a wide character.
			/// The value of MaximumComponentLength may be determined by calling the GetVolumeInformation function. In C, you can determine a
			/// record size by using the following code example.
			/// </para>
			/// <para>
			/// To maintain compatibility across version changes of the change journal software, use a run-time calculation to determine the
			/// size of the
			/// </para>
			/// <para>USN_RECORD_V2</para>
			/// <para>structure. For more information about compatibility across version changes, see the Remarks section in this topic.</para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 2.0, the major version number is 2.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 2.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;

			/// <summary>
			/// <para>The ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public ulong FileReferenceNumber;

			/// <summary>
			/// <para>The ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public ulong ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>The standard UTC time stamp (FILETIME) of this record, in 64-bit format.</summary>
			public FILETIME TimeStamp;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the two following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. An example might be a virus detector adding checksum
			/// information. As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates
			/// that the modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>The unique security identifier assigned to the file or directory associated with this record.</summary>
			public uint SecurityId;

			/// <summary>
			/// The attributes for the file or directory associated with this record, as returned by the GetFileAttributes function.
			/// Attributes of streams associated with the file or directory are excluded.
			/// </summary>
			public uint FileAttributes;

			/// <summary>
			/// The length of the name of the file or directory associated with this record, in bytes. The <c>FileName</c> member contains
			/// this name. Use this member to determine file name length, rather than depending on a trailing '\0' to delimit the file name
			/// in <c>FileName</c>.
			/// </summary>
			public ushort FileNameLength;

			/// <summary>The offset of the <c>FileName</c> member from the beginning of the structure.</summary>
			public ushort FileNameOffset;

			/// <summary>
			/// <para>
			/// The name of the file or directory associated with this record in Unicode format. This file or directory name is of variable length.
			/// </para>
			/// <para>
			/// When working with <c>FileName</c>, do not count on the file name that contains a trailing '\0' delimiter, but instead
			/// determine the length of the file name by using <c>FileNameLength</c>.
			/// </para>
			/// <para>
			/// Do not perform any compile-time pointer arithmetic using <c>FileName</c>. Instead, make necessary calculations at run time by
			/// using the value of the <c>FileNameOffset</c> member. Doing so helps make your code compatible with any future versions of <c>USN_RECORD_V2</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public char FileName;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 3.0 record. The version 2.0 record is defined
		/// by the USN_RECORD_V2 structure (also called <c>USN_RECORD</c> structure).
		/// </summary>
		/// <remarks>
		/// <para>
		/// In output buffers returned from DeviceIoControl operations that work with <c>USN_RECORD_V3</c>, all records are aligned on 64-bit
		/// boundaries from the start of the buffer.
		/// </para>
		/// <para>When range tracking is turned on, NTFS switches to producing only <c>USN_RECORD_V3</c> records as output.</para>
		/// <para>
		/// To provide a path for upward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V3</c> structure. Your code should examine these values, detect its own
		/// compatibility with the change journal software, and if necessary gracefully handle any incompatibility.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V3</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, this makes the C code unreliable. Instead, rely on run-time calculations by using the
		/// <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V3</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, it should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v3 typedef struct { DWORD RecordLength; WORD
		// MajorVersion; WORD MinorVersion; FILE_ID_128 FileReferenceNumber; FILE_ID_128 ParentFileReferenceNumber; USN Usn; LARGE_INTEGER
		// TimeStamp; DWORD Reason; DWORD SourceInfo; DWORD SecurityId; DWORD FileAttributes; WORD FileNameLength; WORD FileNameOffset; WCHAR
		// FileName[1]; } USN_RECORD_V3, *PUSN_RECORD_V3;
		[PInvokeData("winioctl.h", MSDNShortId = "6d95c5d1-6c6b-498f-a00d-eaa540e8b15b")]
		[StructLayout(LayoutKind.Sequential, Size = 80)]
		public struct USN_RECORD_V3
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because <c>USN_RECORD_V3</c> is a variable size, the <c>RecordLength</c> member should be used when calculating the address
			/// of the next record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl
			/// function that work with <c>USN_RECORD_V3</c>.
			/// </para>
			/// <para>
			/// The size in bytes of any change journal record is at most the size of the <c>USN_RECORD_V3</c> structure, plus
			/// MaximumComponentLength characters minus 1 (for the character declared in the structure) times the size of a wide character.
			/// The value of MaximumComponentLength may be determined by calling the GetVolumeInformation function. In C, you can determine a
			/// record size by using the following code example.
			/// </para>
			/// <para>
			/// To maintain compatibility across version changes of the change journal software, use a run-time calculation to determine the
			/// size of the
			/// </para>
			/// <para>USN_RECORD_V3</para>
			/// <para>structure. For more information about compatibility across version changes, see the Remarks section in this topic.</para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 3.0, the major version number is 3.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 3.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;

			/// <summary>
			/// <para>The 128-bit ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public FILE_ID_128 FileReferenceNumber;

			/// <summary>
			/// <para>The 128-bit ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public FILE_ID_128 ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>The standard UTC time stamp (FILETIME) of this record, in 64-bit format.</summary>
			public FILETIME TimeStamp;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V3 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V3 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the two following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. An example might be a virus detector adding checksum
			/// information. As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates
			/// that the modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>The unique security identifier assigned to the file or directory associated with this record.</summary>
			public uint SecurityId;

			/// <summary>
			/// The attributes for the file or directory associated with this record, as returned by the GetFileAttributes function.
			/// Attributes of streams associated with the file or directory are excluded.
			/// </summary>
			public uint FileAttributes;

			/// <summary>
			/// The length of the name of the file or directory associated with this record, in bytes. The <c>FileName</c> member contains
			/// this name. Use this member to determine file name length, rather than depending on a trailing '\0' to delimit the file name
			/// in <c>FileName</c>.
			/// </summary>
			public ushort FileNameLength;

			/// <summary>The offset of the <c>FileName</c> member from the beginning of the structure.</summary>
			public ushort FileNameOffset;

			/// <summary>
			/// <para>
			/// The name of the file or directory associated with this record in Unicode format. This file or directory name is of variable length.
			/// </para>
			/// <para>
			/// When working with <c>FileName</c>, do not count on the file name that contains a trailing '\0' delimiter, but instead
			/// determine the length of the file name by using <c>FileNameLength</c>.
			/// </para>
			/// <para>
			/// Do not perform any compile-time pointer arithmetic using <c>FileName</c>. Instead, make necessary calculations at run time by
			/// using the value of the <c>FileNameOffset</c> member. Doing so helps make your code compatible with any future versions of <c>USN_RECORD_V3</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public char FileName;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 4.0 record. The version 2.0 and 3.0 records
		/// are defined by the USN_RECORD_V2 (also called <c>USN_RECORD</c>) and USN_RECORD_V3 structures respectively.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A <c>USN_RECORD_V4</c> record is only output when range tracking is turned on and the file size is equal or larger than the value
		/// of the <c>RangeTrackFileSizeThreshold</c> member. The user always receives one or more <c>USN_RECORD_V4</c> records followed by
		/// one USN_RECORD_V3 record.
		/// </para>
		/// <para>
		/// To provide a path forward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V4</c> structure. Your code should examine these values, examine its own
		/// compatibility with the change journal software, and gracefully handle any incompatibility if necessary.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V4</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, a change in the minor version number makes the call unreliable. Instead, rely on run-time
		/// calculations that use the <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V4</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, the code should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v4 typedef struct { USN_RECORD_COMMON_HEADER
		// Header; FILE_ID_128 FileReferenceNumber; FILE_ID_128 ParentFileReferenceNumber; USN Usn; DWORD Reason; DWORD SourceInfo; DWORD
		// RemainingExtents; WORD NumberOfExtents; WORD ExtentSize; USN_RECORD_EXTENT Extents[1]; } USN_RECORD_V4, *PUSN_RECORD_V4;
		[PInvokeData("winioctl.h", MSDNShortId = "2636D1A1-6FD1-4F84-954C-499DCCE6E390")]
		[StructLayout(LayoutKind.Sequential, Size = 80)]
		public struct USN_RECORD_V4
		{
			/// <summary>
			/// A USN_RECORD_COMMON_HEADER structure that describes the record length, major version, and minor version for the record.
			/// </summary>
			public USN_RECORD_COMMON_HEADER Header;

			/// <summary>
			/// <para>The 128-bit ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This value is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public FILE_ID_128 FileReferenceNumber;

			/// <summary>
			/// <para>The 128-bit ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This value is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public FILE_ID_128 ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V4 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V4 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a committed TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continue to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. One example is a virus detector adding checksum information.
			/// As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates that the
			/// modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>
			/// The number of extents that remain after the current <c>USN_RECORD_V4</c> record. Multiple version 4.0 records may be required
			/// to describe all of the modified extents for a given file. When the <c>RemainingExtents</c> member is 0, the current
			/// <c>USN_RECORD_V4</c> record is the last <c>USN_RECORD_V4</c> record for the file. The last <c>USN_RECORD_V4</c> entry for a
			/// given file is always followed by a USN_RECORD_V3 record with at least the <c>USN_REASON_CLOSE</c> flag set.
			/// </summary>
			public uint RemainingExtents;

			/// <summary>The number of extents in current <c>USN_RECORD_V4</c> entry.</summary>
			public ushort NumberOfExtents;

			/// <summary>The size of each USN_RECORD_EXTENT structure in the <c>Extents</c> member, in bytes.</summary>
			public ushort ExtentSize;

			/// <summary>An array of USN_RECORD_EXTENT structures that represent the extents in the <c>USN_RECORD_V4</c> entry.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public USN_RECORD_EXTENT[] Extents;
		}

		/// <summary>
		/// Contains information on range tracking parameters for an update sequence number (USN) change journal using the
		/// FSCTL_USN_TRACK_MODIFIED_RANGES control code.
		/// </summary>
		/// <remarks>
		/// Once range tracking is enabled for a given volume it cannot be disabled except by deleting the USN Journal and recreating it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_track_modified_ranges typedef struct { DWORD Flags;
		// DWORD Unused; DWORDLONG ChunkSize; LONGLONG FileSizeThreshold; } USN_TRACK_MODIFIED_RANGES, *PUSN_TRACK_MODIFIED_RANGES;
		[PInvokeData("winioctl.h", MSDNShortId = "00254BBD-8F38-46AB-8B0A-3094020A48C5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_TRACK_MODIFIED_RANGES
		{
			/// <summary>
			/// <para>Indicates enabling range tracking.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE 0x00000001</term>
			/// <term>This flag is mandatory with FSCTL_USN_TRACK_MODIFIED_RANGES and is used to enable range tracking on the volume.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>Reserved.</summary>
			public uint Unused;

			/// <summary>Chunk size for tracking ranges. A single byte modification will be reflected as the whole chunk being modified.</summary>
			public ulong ChunkSize;

			/// <summary>
			/// File size threshold to start outputting USN_RECORD_V4 record(s) for modified file, i.e. if the modified file size is less
			/// than this threshold, then no <c>USN_RECORD_V4</c> record will be output.
			/// </summary>
			public long FileSizeThreshold;
		}

		/*

winioctl_CHANGER_ELEMENT_STATUS	Represents the status of the specified element.
winioctl_CHANGER_ELEMENT_STATUS_EX	Represents the status of the specified element.
winioctl_CHANGER_EXCHANGE_MEDIUM	Contains information the IOCTL_CHANGER_EXCHANGE_MEDIUM control code uses to move a piece of media to a destination, and the piece of media originally in the first destination to a second destination.
winioctl_CHANGER_INITIALIZE_ELEMENT_STATUS	Represents the status of all media changer elements or the specified elements of a particular type.
winioctl_CHANGER_MOVE_MEDIUM	Contains information that the IOCTL_CHANGER_MOVE_MEDIUM control code uses to move a piece of media to a destination.
winioctl_CHANGER_PRODUCT_DATA	Represents product data for a changer device. It is used by the IOCTL_CHANGER_GET_PRODUCT_DATA control code.
winioctl_CHANGER_READ_ELEMENT_STATUS	Contains information that the IOCTL_CHANGER_GET_ELEMENT_STATUS control code needs to determine the elements whose status is to be retrieved.
winioctl_CHANGER_SEND_VOLUME_TAG_INFORMATION	Contains information that the IOCTL_CHANGER_QUERY_VOLUME_TAGS control code uses to determine the volume information to be retrieved.
winioctl_CHANGER_SET_ACCESS	Contains information that the IOCTL_CHANGER_SET_ACCESS control code needs to set the state of the device's insert/eject port, door, or keypad.
winioctl_CHANGER_SET_POSITION	Contains information needed by the IOCTL_CHANGER_SET_POSITION control code to set the changer's robotic transport mechanism to the specified element address.
winioctl_CLASS_MEDIA_CHANGE_CONTEXT	Contains information associated with a media change event.
winioctl_CREATE_DISK	Contains information that the IOCTL_DISK_CREATE_DISK control code uses to initialize GUID partition table (GPT), master boot record (MBR), or raw disks.
winioctl_CREATE_DISK_GPT	Contains information used by the IOCTL_DISK_CREATE_DISK control code to initialize GUID partition table (GPT) disks.
winioctl_CREATE_DISK_MBR	Contains information that the IOCTL_DISK_CREATE_DISK control code uses to initialize master boot record (MBR) disks.
winioctl_CREATE_USN_JOURNAL_DATA	Contains information that describes an update sequence number (USN) change journal.
winioctl_CSV_CONTROL_PARAM	Represents a type of CSV control operation.
winioctl_CSV_IS_OWNED_BY_CSVFS	Contains the output for the FSCTL_IS_VOLUME_OWNED_BYCSVFS control code that determines whether a volume is owned by CSVFS.
winioctl_CSV_NAMESPACE_INFO	Contains the output for the FSCTL_IS_CSV_FILE control code that retrieves namespace information for a file.
winioctl_CSV_QUERY_FILE_REVISION	Contains information about whether files in a stream have been modified.
winioctl_CSV_QUERY_MDS_PATH	Contains the path that is used by CSV to communicate to the MDS.
winioctl_CSV_QUERY_REDIRECT_STATE	Contains information about whether files in a stream have been redirected.
winioctl_CSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT	Contains troubleshooting information about why a volume is in redirected mode.
winioctl_DELETE_USN_JOURNAL_DATA	Contains information on the deletion of an update sequence number (USN) change journal using the FSCTL_DELETE_USN_JOURNAL control code.
winioctl_DEVICE_COPY_OFFLOAD_DESCRIPTOR	Contains the copy offload capabilities for a storage device.
winioctl_DEVICE_DATA_SET_LB_PROVISIONING_STATE	Output structure for the DeviceDsmAction_Allocation action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_DATA_SET_RANGE	Provides data set range information for use with the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_DATA_SET_REPAIR_PARAMETERS	Specifies parameters for the repair operation.
winioctl_DEVICE_DSM_NOTIFICATION_PARAMETERS	Contains parameters for the DeviceDsmAction_Notification action for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_DSM_OFFLOAD_READ_PARAMETERS	Contains parameters for the DeviceDsmAction_OffloadRead action for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS	Specifies parameters for the offload write operation.
winioctl_DEVICE_LB_PROVISIONING_DESCRIPTOR	Contains the thin provisioning capabilities for a storage device.
winioctl_DEVICE_MANAGE_DATA_SET_ATTRIBUTES	Input structure for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT	Output structure for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_DEVICE_MEDIA_INFO	Provides information about the media supported by a device.
winioctl_DEVICE_POWER_DESCRIPTOR	The DEVICE_POWER_DESCRIPTOR structure describes the power capabilities of a storage device.
winioctl_DEVICE_SEEK_PENALTY_DESCRIPTOR	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to retrieve the seek penalty descriptor data for a device.
winioctl_DEVICE_TRIM_DESCRIPTOR	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to retrieve the trim descriptor data for a device.
winioctl_DEVICE_WRITE_AGGREGATION_DESCRIPTOR	Reserved for system use.
winioctl_DISK_CACHE_INFORMATION	Provides information about the disk cache.
winioctl_DISK_DETECTION_INFO	Contains detected drive parameters.
winioctl_DISK_EX_INT13_INFO	Contains extended Int13 drive parameters.
winioctl_DISK_EXTENT	Represents a disk extent.
winioctl_DISK_GEOMETRY	Describes the geometry of disk devices and media.
winioctl_DISK_GEOMETRY_EX	Describes the extended geometry of disk devices and media.
winioctl_DISK_GROW_PARTITION	Contains information used to increase the size of a partition.
winioctl_DISK_INT13_INFO	Contains standard Int13 drive geometry parameters.
winioctl_DISK_PARTITION_INFO	Contains the disk partition information.
winioctl_DISK_PERFORMANCE	Provides disk performance information.
winioctl_DRIVE_LAYOUT_INFORMATION	Contains information about the partitions of a drive.
winioctl_DRIVE_LAYOUT_INFORMATION_EX	Contains extended information about a drive's partitions.
winioctl_DRIVE_LAYOUT_INFORMATION_GPT	Contains information about a drive's GUID partition table (GPT) partitions.
winioctl_DRIVE_LAYOUT_INFORMATION_MBR	Provides information about a drive's master boot record (MBR) partitions.
winioctl_DUPLICATE_EXTENTS_DATA	Contains parameters for the FSCTL_DUPLICATE_EXTENTS control code that performs the Block Cloning operation.
winioctl_EXFAT_STATISTICS	Contains statistical information from the exFAT file system.
winioctl_FAT_STATISTICS	Contains statistical information from the FAT file system.
winioctl_FILE_ALLOCATED_RANGE_BUFFER	Indicates a range of bytes in a file.
winioctl_FILE_LEVEL_TRIM	Used as input to the FSCTL_FILE_LEVEL_TRIM control code.
winioctl_FILE_LEVEL_TRIM_OUTPUT	Used as output to the FSCTL_FILE_LEVEL_TRIM control code.
winioctl_FILE_LEVEL_TRIM_RANGE	Specifies a range of a file that is to be trimmed.
winioctl_FILE_MAKE_COMPATIBLE_BUFFER	Specifies the disc to close the current session for. This control code is used for UDF file systems. This structure is used for input when calling FSCTL_MAKE_MEDIA_COMPATIBLE.
winioctl_FILE_OBJECTID_BUFFER	Contains an object identifier and user-defined metadata associated with the object identifier.
winioctl_FILE_QUERY_ON_DISK_VOL_INFO_BUFFER	Receives the volume information from a call to FSCTL_QUERY_ON_DISK_VOLUME_INFO.
winioctl_FILE_QUERY_SPARING_BUFFER	Contains defect management properties.
winioctl_FILE_SET_DEFECT_MGMT_BUFFER	Specifies the defect management state to be set.
winioctl_FILE_SET_SPARSE_BUFFER	Specifies the sparse state to be set.
winioctl_FILE_STORAGE_TIER	Represents an identifier for the storage tier relative to the volume.
winioctl_FILE_STORAGE_TIER_REGION	Describes a single storage tier region.
winioctl_FILE_SYSTEM_RECOGNITION_INFORMATION	Contains file system recognition information retrieved by the FSCTL_QUERY_FILE_SYSTEM_RECOGNITION control code.
winioctl_FILE_ZERO_DATA_INFORMATION	Contains a range of a file to set to zeros.
winioctl_FILESYSTEM_STATISTICS	Contains statistical information from the file system.
winioctl_FILESYSTEM_STATISTICS_EX	Contains statistical information from the file system.Support for this structure started with Windows 10.
winioctl_FIND_BY_SID_DATA	Contains data for the FSCTL_FIND_FILES_BY_SID control code.
winioctl_FIND_BY_SID_OUTPUT	Represents a file name.
winioctl_FORMAT_EX_PARAMETERS	Contains information used in formatting a contiguous set of disk tracks. It is used by the IOCTL_DISK_FORMAT_TRACKS_EX control code.
winioctl_FORMAT_PARAMETERS	Contains information used in formatting a contiguous set of disk tracks.
winioctl_FSCTL_GET_INTEGRITY_INFORMATION_BUFFER	Contains the integrity information for a file or directory.
winioctl_FSCTL_QUERY_REGION_INFO_INPUT	Contains the storage tier regions from the storage stack for a particular volume.
winioctl_FSCTL_QUERY_REGION_INFO_OUTPUT	Contains information for one or more regions.
winioctl_FSCTL_QUERY_STORAGE_CLASSES_OUTPUT	Contains information for all tiers of a specific volume.
winioctl_FSCTL_SET_INTEGRITY_INFORMATION_BUFFER	Input buffer passed with the FSCTL_SET_INTEGRITY_INFORMATION control code.
winioctl_GET_CHANGER_PARAMETERS	Represents the parameters of a changer.
winioctl_GET_DISK_ATTRIBUTES	Contains the attributes of a disk device.
winioctl_GET_LENGTH_INFORMATION	Contains disk, volume, or partition length information used by the IOCTL_DISK_GET_LENGTH_INFO control code.
winioctl_GET_MEDIA_TYPES	Contains information about the media types supported by a device.
winioctl_LOOKUP_STREAM_FROM_CLUSTER_ENTRY	Returned from the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code.
winioctl_LOOKUP_STREAM_FROM_CLUSTER_INPUT	Passed as input to the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code.
winioctl_LOOKUP_STREAM_FROM_CLUSTER_OUTPUT	Received as output from the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code.
winioctl_MARK_HANDLE_INFO	Contains information that is used to mark a specified file or directory, and its update sequence number (USN) change journal record with data about changes.
winioctl_MARK_HANDLE_INFO32	Contains information that is used to mark a specified file or directory, and its update sequence number (USN) change journal record with data about changes.
winioctl_MOVE_FILE_DATA	Contains input data for the FSCTL_MOVE_FILE control code.
winioctl_NTFS_EXTENDED_VOLUME_DATA	Represents volume data.
winioctl_NTFS_FILE_RECORD_INPUT_BUFFER	Contains data for the FSCTL_GET_NTFS_FILE_RECORD control code.
winioctl_NTFS_FILE_RECORD_OUTPUT_BUFFER	Receives output data from the FSCTL_GET_NTFS_FILE_RECORD control code.
winioctl_NTFS_STATISTICS	Contains statistical information from the NTFS file system.
winioctl_NTFS_STATISTICS_EX	Contains statistical information from the NTFS file system.Support for this structure started with Windows 10.
winioctl_NTFS_VOLUME_DATA_BUFFER	Represents volume data.
winioctl_PARTITION_INFORMATION	Contains information about a disk partition.
winioctl_PARTITION_INFORMATION_EX	Contains partition information for standard AT-style master boot record (MBR) and Extensible Firmware Interface (EFI) disks.
winioctl_PARTITION_INFORMATION_GPT	Contains GUID partition table (GPT) partition information.
winioctl_PARTITION_INFORMATION_MBR	Contains partition information specific to master boot record (MBR) disks.
winioctl_PLEX_READ_DATA_REQUEST	Indicates the range of the read operation to perform and the plex from which to read.
winioctl_PREVENT_MEDIA_REMOVAL	Provides removable media locking data. It is used by the IOCTL_STORAGE_MEDIA_REMOVAL control code.
winioctl_READ_ELEMENT_ADDRESS_INFO	Represents the volume tag information. It is used by the IOCTL_CHANGER_QUERY_VOLUME_TAGS control code.
winioctl_READ_FILE_USN_DATA	Specifies the versions of the update sequence number (USN) change journal supported by the application.
winioctl_READ_USN_JOURNAL_DATA_V0	Contains information defining a set of update sequence number (USN) change journal records to return to the calling process.
winioctl_READ_USN_JOURNAL_DATA_V1	Contains information defining a set of update sequence number (USN) change journal records to return to the calling process.
winioctl_REASSIGN_BLOCKS	Contains disk block reassignment data.
winioctl_REASSIGN_BLOCKS_EX	Contains disk block reassignment data.
winioctl_REPAIR_COPIES_INPUT	Input structure for the FSCTL_REPAIR_COPIES control code.
winioctl_REPAIR_COPIES_OUTPUT	Contains output of a repair copies operation returned from the FSCTL_REPAIR_COPIES control code.
winioctl_REQUEST_OPLOCK_INPUT_BUFFER	Contains the information to request an opportunistic lock (oplock) or to acknowledge an oplock break with the FSCTL_REQUEST_OPLOCK control code.
winioctl_REQUEST_OPLOCK_OUTPUT_BUFFER	Contains the opportunistic lock (oplock) information returned by the FSCTL_REQUEST_OPLOCK control code.
winioctl_RETRIEVAL_POINTER_BASE	Contains the output for the FSCTL_GET_RETRIEVAL_POINTER_BASE control code.
winioctl_RETRIEVAL_POINTERS_BUFFER	Contains the output for the FSCTL_GET_RETRIEVAL_POINTERS control code.
winioctl_SET_DISK_ATTRIBUTES	Specifies the attributes to be set on a disk device.
winioctl_SET_PARTITION_INFORMATION	Contains information used to set a disk partition's type.
winioctl_SHRINK_VOLUME_INFORMATION	Specifies the volume shrink operation to perform.
winioctl_STARTING_LCN_INPUT_BUFFER	Contains the starting LCN to the FSCTL_GET_VOLUME_BITMAP control code.
winioctl_STARTING_VCN_INPUT_BUFFER	Contains the starting VCN to the FSCTL_GET_RETRIEVAL_POINTERS control code.
winioctl_STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage access alignment descriptor data for a device.
winioctl_STORAGE_ADAPTER_DESCRIPTOR	Used with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage adapter descriptor data for a device.
winioctl_STORAGE_DESCRIPTOR_HEADER	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the properties of a storage device or adapter.
winioctl_STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR	Reserved for future use.
winioctl_STORAGE_DEVICE_DESCRIPTOR	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage device descriptor data for a device.
winioctl_STORAGE_DEVICE_ID_DESCRIPTOR	Used with the IOCTL_STORAGE_QUERY_PROPERTY control code request to retrieve the device ID descriptor data for a device.
winioctl_STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR	The output buffer for the StorageDeviceIoCapabilityProperty as defined in STORAGE_PROPERTY_ID.
winioctl_STORAGE_DEVICE_NUMBER	Contains information about a device. This structure is used by the IOCTL_STORAGE_GET_DEVICE_NUMBER control code.
winioctl_STORAGE_DEVICE_POWER_CAP	This structure is used as an input and output buffer for the IOCTL_STORAGE_DEVICE_POWER_CAP.
winioctl_STORAGE_DEVICE_RESILIENCY_DESCRIPTOR	Reserved for system use.
winioctl_STORAGE_HOTPLUG_INFO	Provides information about the hotplug information of a device.
winioctl_STORAGE_HW_FIRMWARE_ACTIVATE	This structure contains information about the downloaded firmware to activate.
winioctl_STORAGE_HW_FIRMWARE_DOWNLOAD	This structure contains a firmware image payload to be downloaded to the target.
winioctl_STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR	Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to describe the product type of a storage device.
winioctl_STORAGE_MINIPORT_DESCRIPTOR	Reserved for system use.
winioctl_STORAGE_OFFLOAD_READ_OUTPUT	Output structure for the DeviceDsmAction_OffloadRead action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_STORAGE_OFFLOAD_TOKEN	The token used to represent a portion of a file used in by offload read and write operations.
winioctl_STORAGE_OFFLOAD_WRITE_OUTPUT	Output structure for the DeviceDsmAction_OffloadWrite action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
winioctl_STORAGE_PHYSICAL_ADAPTER_DATA	Describes a physical storage adapter.
winioctl_STORAGE_PHYSICAL_DEVICE_DATA	Describes a physical storage device.
winioctl_STORAGE_PHYSICAL_NODE_DATA	Specifies the physical device data of a storage node.
winioctl_STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR	The STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR structure is one of the query result structures returned from an IOCTL_STORAGE_QUERY_PROPERTY request.
winioctl_STORAGE_PROPERTY_QUERY	Indicates the properties of a storage device or adapter to retrieve as the input buffer passed to the IOCTL_STORAGE_QUERY_PROPERTY control code.
winioctl_STORAGE_PROTOCOL_COMMAND	This structure is used as an input buffer when using the pass-through mechanism to issue a vendor-specific command to a storage device (via IOCTL_STORAGE_PROTOCOL_COMMAND).
winioctl_STORAGE_PROTOCOL_DATA_DESCRIPTOR	This structure is used in conjunction with IOCTL_STORAGE_QUERY_PROPERTY to return protocol-specific data from a storage device or adapter.
winioctl_STORAGE_PROTOCOL_SPECIFIC_DATA	Describes protocol-specific device data, provided in the input and output buffer of an IOCTL_STORAGE_QUERY_PROPERTY request.
winioctl_STORAGE_RPMB_DATA_FRAME
winioctl_STORAGE_RPMB_DESCRIPTOR
winioctl_STORAGE_SPEC_VERSION	Storage specification version.
winioctl_STORAGE_TEMPERATURE_DATA_DESCRIPTOR	This structure is used in conjunction with IOCTL_STORAGE_QUERY_PROPERTY to return temperature data from a storage device or adapter.
winioctl_STORAGE_TEMPERATURE_INFO	Describes device temperature data. Returned as part of STORAGE_TEMPERATURE_DATA_DESCRIPTOR when querying for temperature data with an IOCTL_STORAGE_QUERY_PROPERTY request.
winioctl_STORAGE_TEMPERATURE_THRESHOLD	This structure is used to set the over or under temperature threshold of a storage device (via IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD).
winioctl_STORAGE_WRITE_CACHE_PROPERTY	Used with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve information about a device's write cache property.
winioctl_TXFS_CREATE_MINIVERSION_INFO	Contains the version information about the miniversion created by FSCTL_TXFS_CREATE_MINIVERSION.
winioctl_TXFS_GET_METADATA_INFO_OUT	Contains the version information about the miniversion that is created.
winioctl_TXFS_GET_TRANSACTED_VERSION	Contains the information about the base and latest versions of the specified file.
winioctl_TXFS_LIST_TRANSACTION_LOCKED_FILES	Contains a list of files locked by a transacted writer.
winioctl_TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY	Contains information about a locked transaction.
winioctl_TXFS_LIST_TRANSACTIONS	Contains a list of transactions.
winioctl_TXFS_LIST_TRANSACTIONS_ENTRY	Contains information about a transaction.
winioctl_TXFS_MODIFY_RM	Contains the information required when modifying log parameters and logging mode for a secondary resource manager.
winioctl_TXFS_QUERY_RM_INFORMATION	Contains information about the resource manager (RM).
winioctl_TXFS_READ_BACKUP_INFORMATION_OUT	Contains a Transactional NTFS (TxF) specific structure. This information should only be used when calling TXFS_WRITE_BACKUP_INFORMATION.
winioctl_TXFS_SAVEPOINT_INFORMATION	The FSCTL_TXFS_SAVEPOINT_INFORMATION structure specifies the action to perform, and on which transaction.
winioctl_TXFS_TRANSACTION_ACTIVE_INFO	Contains the flag that indicates whether transactions were active or not when a snapshot was taken.
winioctl_TXFS_WRITE_BACKUP_INFORMATION	Contains a Transactional NTFS (TxF) specific structure. This information should only be used when calling TXFS_WRITE_BACKUP_INFORMATION.
winioctl_VERIFY_INFORMATION	Contains information used to verify a disk extent.
winioctl_VOLUME_BITMAP_BUFFER	Represents the occupied and available clusters on a disk.
winioctl_VOLUME_DISK_EXTENTS	Represents a physical location on a disk.
winioctl_VOLUME_GET_GPT_ATTRIBUTES_INFORMATION Contains volume attributes retrieved with the IOCTL_VOLUME_GET_GPT_ATTRIBUTES control code.
*/
	}
}