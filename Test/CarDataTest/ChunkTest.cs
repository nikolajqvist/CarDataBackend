namespace CarDataTest;
using CARDataLib;
using cardataapi;
using System.Threading.Tasks;
[TestClass]
public sealed class ChunkTest{
    private CarDataChunkRepository? chunkRepository;
    [TestInitialize]
    public void TestInitialize(){
        this.chunkRepository = new CarDataChunkRepository("Server=localhost;Database=CARData;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    [TestMethod]
    public void InsertPulseDataChunk(){
        PulseData p = new PulseData(){Pulse = 65};
        PulseData p1 = new PulseData(){Pulse = 65};
        PulseData p2 = new PulseData(){Pulse = 65};
        PulseData p3 = new PulseData(){Pulse = 65};
        PulseData p4 = new PulseData(){Pulse = 65};
        PulseData p5 = new PulseData(){Pulse = 65};
        PulseData p6 = new PulseData(){Pulse = 65};
        PulseData p7 = new PulseData(){Pulse = 65
        };
        PulseData p8 = new PulseData(){
            Pulse = 65
        };
        PulseData p9 = new PulseData(){
            Pulse = 65
        };
        List<PulseData> pulseDatas = new List<PulseData>();
        pulseDatas.Add(p); 
        pulseDatas.Add(p2); 
        pulseDatas.Add(p3); 
        pulseDatas.Add(p4); 
        pulseDatas.Add(p4); 
        pulseDatas.Add(p5); 
        pulseDatas.Add(p6); 
        pulseDatas.Add(p7); 
        pulseDatas.Add(p8); 
        pulseDatas.Add(p9); 
        chunkRepository.AddPulseData(pulseDatas, 16128); 
        int expecetedCount = 10;
        int actualCount = pulseDatas.Count;
        Assert.AreEqual(expecetedCount, actualCount);
    }
    [TestMethod]
    public void InsertBikeDataChunk(){
        List<BikeData> bikeDatas = new List<BikeData>(){
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
            new BikeData(){
                HandleRotationY = 0.58384,
                DistanceCurbSide = 0.58485,
                Speed = 0.48558
            },
        };
        chunkRepository.AddBikeData(bikeDatas, 16128);
        int expecetedCount = 7;
        int actualCount = bikeDatas.Count;
        Assert.AreEqual(expecetedCount, actualCount);
    }
    [TestMethod]
    public async Task InsertHeadTransform(){
        List<HeadTransform> hTfs = new List<HeadTransform>(){
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },

            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            },
            new HeadTransform(){
                RotW = 0.40404,
                RotX = 0.40404,
                RotY = 0.40404,
                RotZ = 0.40404,
                PosX = 0.40404,
                PosZ = 0.40404,
                PosY = 0.40404,
            }
        };
        chunkRepository.AddHeadTransform(hTfs, 16128);
        int expecetedCount = 8;
        int actualCount = hTfs.Count;
        Assert.AreEqual(expecetedCount, actualCount);
    }
}
