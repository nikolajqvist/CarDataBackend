namespace cardataapi;
using CARDataLib;

public class FileHandlerService{
    private CarDataSqliteChunkRepository carDataSqliteChunkRepository;
    public FileHandlerService(CarDataSqliteChunkRepository carDataSqliteChunkRepository){
        this.carDataSqliteChunkRepository = carDataSqliteChunkRepository;
    }
    public async void HandleBikeData(IncomingFile incomingFile, int userId){
        if(incomingFile.newTestFile == null || incomingFile.newTestFile.Length == 0){
            throw new ArgumentNullException("Fil fejl");
        }
        var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "userBikeData");
        var filepath = Path.Combine("userBikeData", incomingFile.newTestFile.FileName);

        Directory.CreateDirectory(folderpath);
        FileStream stream = new FileStream(filepath, FileMode.Create);
        using(stream){
            await incomingFile.newTestFile.CopyToAsync(stream);
        }
        string fileContent = await System.IO.File.ReadAllTextAsync(filepath);
        if(fileContent.Length == 0 && fileContent == null)
            throw new ArgumentNullException("Læse fejl");
        string[] stringSplit = fileContent.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);

        var chunks = stringSplit.Chunk(3);

        List<BikeData> bikeDatas = new List<BikeData>();

        foreach (string[] chunk in chunks){
            if(chunk.Length < 3) {
                throw new ArgumentOutOfRangeException("Chunk skal minimum være 3");
            };
            var yRot = double.Parse(chunk[0]);
            double curbSide = double.Parse(chunk[1]);
            double spee = double.Parse(chunk[2]);
            BikeData p = new BikeData();
            p.HandleRotationY = yRot;
            p.DistanceCurbSide = curbSide;
            p.Speed = spee;
            bikeDatas.Add(p);
        }
        carDataSqliteChunkRepository.AddBikeData(bikeDatas, userId);
    }
    public async void HandlePulseData(IncomingFile incomingFile, int userId){
        if(incomingFile == null || incomingFile.newTestFile.Length == 0){
            throw new ArgumentNullException("File fejl");
        }
        var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "userPulseData");
        var filepath = Path.Combine("userPulseData", incomingFile.newTestFile.FileName);

        Directory.CreateDirectory(folderpath);
        FileStream stream = new FileStream(filepath, FileMode.Create);
        using(stream){
            await incomingFile.newTestFile.CopyToAsync(stream);
        }
        string fileContent = System.IO.File.ReadAllText(filepath);
        if(fileContent.Length == 0 || fileContent == null){
            throw new ArgumentNullException("Intet indhold");
        }
        string[] contentSplit = fileContent.Split("\n");

        List<PulseData> pulseDatas = new List<PulseData>();

        foreach(string line in contentSplit){
            int puls = int.Parse(line);
            PulseData pulseObject = new PulseData();
            pulseObject.Pulse = puls;
            pulseDatas.Add(pulseObject);
        }
        carDataSqliteChunkRepository.AddPulseData(pulseDatas, userId);
    }
    public async void HandleHeadTrans(IncomingFile incomingFile, int userId){
        if(incomingFile == null || incomingFile.newTestFile.Length == 0){
            throw new ArgumentNullException("File fejl");
        }
        var filepath = Path.Combine("userHeadTransform", incomingFile.newTestFile.FileName);
        var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "userHeadTransform");

        Directory.CreateDirectory(folderpath);
        FileStream stream = new FileStream(filepath, FileMode.Create);
        using(stream){
            await incomingFile.newTestFile.CopyToAsync(stream);
        }
        string fileContent = System.IO.File.ReadAllText(filepath);
        if(fileContent.Length == 0 || fileContent == null){
            throw new ArgumentNullException("Intet indhold");
        }
        string[] contentSplit = fileContent.Split(new[] {"\n", "\n", "\n", "\n", "\n", "\n", "\n"}, StringSplitOptions.None);
        
        var chunks = contentSplit.Chunk(7);

        List<HeadTransform> hTfs = new List<HeadTransform>();

        foreach(string[] chunk in chunks){
            double rw = double.Parse(chunk[0]);
            double rz = double.Parse(chunk[1]);
            double rx = double.Parse(chunk[2]);
            double ry = double.Parse(chunk[3]);
            double px = double.Parse(chunk[4]);
            double py = double.Parse(chunk[5]);
            double pz = double.Parse(chunk[6]);
            HeadTransform htf = new HeadTransform();
            htf.RotW = rw;
            htf.RotZ = rz;
            htf.RotX = rx;
            htf.RotY = ry;
            htf.PosZ = pz;
            htf.PosX = px;
            htf.PosY = py;
            hTfs.Add(htf);
        }
        carDataSqliteChunkRepository.AddHeadTransform(hTfs, userId);
    }
    public async void HandleScenarios(IncomingFile incomingFile){
        ValidateFile(incomingFile);
        var filepath = CreateFilePath(incomingFile, "userScenarios");
        var folderpath = CreateFolderPath("userScenarios");
        
        CreateDirectory(folderpath);

        FileStream stream = new FileStream(filepath, FileMode.Create);
        using(stream){
            await incomingFile.newTestFile.CopyToAsync(stream);
        }
        string fileContent = ReadFile(filepath);
        if(fileContent.Length == 0 || fileContent == null){
            throw new ArgumentNullException("Intet indhold");
        }
        string[] splitContent = fileContent.Split(new[] {"\n", "\n", "\n", "\n", "\n"}, StringSplitOptions.None);
        
        var chunks = splitContent.Chunk(5);

        List<Scenario> scenarios = new List<Scenario>();

        foreach(string[] chunk in chunks){
            if(chunk.Length < 5) throw new ArgumentOutOfRangeException("Chunk er for lille");
            int id = int.Parse(chunk[0]);
            string sceName = chunk[1];
            double cycToCarDist = double.Parse(chunk[2]);
            DateTime start = DateTime.Parse(chunk[3]);
            DateTime end = DateTime.Parse(chunk[4]);
            Scenario sce = new Scenario();
            sce.SessionId = id;
            sce.ScenarioName = sceName;
            sce.CycleToCarDistance = cycToCarDist;
            sce.ScenarioStart = start;
            sce.ScenarioEnd = end;
            scenarios.Add(sce);
        }
        carDataSqliteChunkRepository.AddScenarios(scenarios);
    }
    public async void HandleTimeCheck(IncomingFile incomingFile){
        ValidateFile(incomingFile);
        var filepath = CreateFilePath(incomingFile, "userTimeCheck");
        var folderpath = CreateFolderPath("userTimeCheck");
        CreateDirectory(folderpath);

        FileStream stream = new FileStream(filepath, FileMode.Create);
        using(stream){
            await incomingFile.newTestFile.CopyToAsync(stream);
        }
        string fileContent = ReadFile(filepath);
        if(fileContent.Length == 0 || fileContent == null){
            throw new ArgumentNullException("Intet indhold");
        }
        string[] fileSplit = fileContent.Split("\n");
        
        List<TimeCheck> timeChecks = new List<TimeCheck>();

        foreach(string line in fileSplit){
            int time = int.Parse(line);
            TimeCheck tC = new TimeCheck();
            tC.Time = time;
            timeChecks.Add(tC);
        }
        carDataSqliteChunkRepository.AddTimeCheck(timeChecks);
    }
    private void ValidateFile(IncomingFile incomingFile){
        if(incomingFile.newTestFile.Length == 0 || incomingFile == null){
            throw new ArgumentNullException("File fejl");
        }
    }
    private string CreateFolderPath(string folderName){
        string folderpath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        return folderpath;
    }
    private string CreateFilePath(IncomingFile incomingFile, string filePath){
        string filepath = Path.Combine(filePath, incomingFile.newTestFile.FileName);
        return filepath;

    }
    private void CreateDirectory(string folderpath){
        Directory.CreateDirectory(folderpath);
    }
    private string ReadFile(string filepath){
        string fileContent = System.IO.File.ReadAllText(filepath);
        return fileContent;
    }
}
