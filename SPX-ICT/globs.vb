Module globs
    Public ReadOnly AppNM As String = "SPX-ICT"
    Public ReadOnly AppVR As String = "b0.0.1"
    Public ReadOnly credits As String = "Cobs - Programming & Design, Bwenfwake - Images, Deinsti - Testing"


    'SPX-ICT
    Public useDarkMode As Boolean = False


    'Drivers tab
    Public IsBMRbeingUsed As Boolean = False
    Public BMRType As String = "ZIP"
    Public BMRPath As String = Nothing

    Public ExistingDriversZipInUse As Boolean = False
    Public DriversZipPath As String = Nothing

    'Installation Media
    Public usingISOfile As Boolean = True
    Public ISOPath As String = Nothing

    Public usingWIMfiles As Boolean = False
    Public bootwimpath As String = Nothing
    Public installwimpath As String = Nothing

    'Indexes
    Public updateBothBootWimIndexes As Boolean = True
    Public defaultBootWimIndex As Object = bootWimIndex1 'Only to be used if above is false
    Public bootWimIndex1 As Integer = 1
    Public bootWimIndex2 As Integer = 2
    Public InstallationIndex

    'Optional
    Public useBuiltInZIPExtractor As Boolean = True
    Public usePowerShellToExtractZIP As Boolean = False
    Public use7ZipToExtractZip As Boolean = False

    'Dependancies
    Public powerShellLocation As String = ""
    Public sevenzipLocation As String = ""
    Public dismLocation As String = ""
    Public cmdLocation As String = ""

    'workingdir
    Public basepath = "c:\spx-ict" 'we want this short and basic for use with DISM.

    'surface type
    Public surfaceType As String = "sq1"
    Public knownHashes = {"B004CCCDC97D52C747357C34A782F3E8", ""}
    Public knownFiles = {"SurfaceProX_SQ1_2019_Win10_20H2_BMR_172_130.228.3.zip", ""}

End Module
