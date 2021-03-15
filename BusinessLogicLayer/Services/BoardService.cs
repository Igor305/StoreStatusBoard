using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.Shops;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BoardService : IBoardService
    {
        private readonly IMonitoringRepository _monitoringRepository;
        private readonly IRStockRepository _rStockRepository;

        private readonly IShopsRepository _shopsRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IShopProvidersRepository _shopProvidersRepository;
        private readonly ITempImportAddressesRepository _tempImportAddressesRepository;
        private readonly IShopRegionLocalizationsRepository _shopRegionLocalizationsRepository;
        private readonly IShopWorkTimesRepository _shopWorkTimesRepository;

        private readonly IMapper _mapper;

        public BoardService (IMonitoringRepository monitoringRepository, IRStockRepository rStockRepository,
        IShopsRepository shopsRepository, IProviderRepository providerRepository,
            IShopProvidersRepository shopProvidersRepository, IShopRegionLocalizationsRepository shopRegionLocalizationsRepository,
            ITempImportAddressesRepository tempImportAddressesRepository, IShopWorkTimesRepository shopWorkTimesRepository,
            IMapper mapper)
        {
            _monitoringRepository = monitoringRepository;
            _rStockRepository = rStockRepository;

            _shopsRepository = shopsRepository;
            _providerRepository = providerRepository;
            _shopProvidersRepository = shopProvidersRepository;
            _tempImportAddressesRepository = tempImportAddressesRepository;
            _shopWorkTimesRepository = shopWorkTimesRepository;
            _shopRegionLocalizationsRepository = shopRegionLocalizationsRepository;

            _mapper = mapper;
        }

        public async Task<BoardResponseModel> getStartBoard()
        {
            BoardResponseModel responseModel = new BoardResponseModel();

            int nstock = await _rStockRepository.getAmountShop();

         /*   List<Monitoring> monitoringsR = await _monitoringRepository.getStartStocksR(nstock);
            List<Monitoring> monitoringsS = new List<Monitoring>();

            for (int x = 1; x <= nstock; x++)
            {

                Monitoring monitoringS = await _monitoringRepository.getStartStocksS(x);
                if (monitoringS != null)
                {
                    monitoringsS.Add(monitoringS);
                }
            }*/

            return responseModel;
        }

        public async Task<BoardResponseModel> getBoard()
        {
            BoardResponseModel responseModel = new BoardResponseModel();

            int amount = await _monitoringRepository.getCountStock();

            List<int?> greenFrom5Day = await _monitoringRepository.getGreenFrom5Day();


            int?[] greyFrom5Day = new int?[amount+1];

            for (int i = 1; i <= amount; i++)
            {

                for (int y = 0; y < greenFrom5Day.Count; y++)
                {

                    if (i == greenFrom5Day[y])
                    {
                        greyFrom5Day[i] = 0;break;
                    }
                    else
                    {
                        greyFrom5Day[i] = 1;
                    }
                }
            }

            List<Monitoring> monitoringsR = await _monitoringRepository.getStocksR(amount);
            List<Monitoring> monitoringsS = await _monitoringRepository.getStocksS(amount);

            int?[] statusS = new int?[amount];

            for (int i = 0; i < amount; i++)
            {
                statusS[i] = monitoringsS[i].Status;

            }

            int count = 1;

            responseModel.amount = amount;
            responseModel.monitoringModels = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(monitoringsR);
            responseModel.monitoringModels.ForEach(x => x.isGrey = greyFrom5Day[count++]);
            count = 0;
            responseModel.monitoringModels.ForEach(x => x.StatusS = statusS[count++]);

           return responseModel;
        }

        public async Task<ShopResponseModel> getShopInfo(int nshop)
        {
            ShopResponseModel shopResponseModel = new ShopResponseModel();

            DateTime workTimeFrom = await _shopWorkTimesRepository.getShopWorkTimesFrom(nshop);
            DateTime workTimeTo = await _shopWorkTimesRepository.getShopWorkTimesTo(nshop);

            shopResponseModel.WorkTimeFrom = workTimeFrom.ToShortTimeString();
            shopResponseModel.WorkTimeTo = workTimeTo.ToShortTimeString();

            Shop shop = await _shopsRepository.getShop(nshop);

            ShopModel shopModel = _mapper.Map<Shop, ShopModel>(shop);

            shopResponseModel.Region = await _shopRegionLocalizationsRepository.getRegion(shopModel.ShopRegionId);
            shopResponseModel.City = await _tempImportAddressesRepository.getShopCity(shopModel.StreetId);
            shopResponseModel.Street = await _tempImportAddressesRepository.getShopStreet(shopModel.StreetId);
            shopResponseModel.Number = shopModel.Address;

            List<ProviderModel> providerModels = new List<ProviderModel>();


            List<int> providers = await _shopProvidersRepository.getShopProvider(nshop);

            for (int x = 0; x < providers.Count; x++)
            {
                providerModels.Add(new ProviderModel()
                {
                    Name = await _providerRepository.getProviderName(providers[x]),
                    PhoneNumber = await _providerRepository.getProviderPhoneNumber(providers[x])
                });
            }

            shopResponseModel.Providers = providerModels;

            return shopResponseModel;
        }

        public async Task<StatusForDayResponseModel> getStatusForDay(int nshop)
        {
            StatusForDayResponseModel statusForDayResponseModel = new StatusForDayResponseModel();

            List<Monitoring> monitorings7 = await _monitoringRepository.getStatusStockHours(nshop, 7);
            List<Monitoring> monitorings7m = await _monitoringRepository.getStatusStock30Minutes(nshop, 7);     

            List<Monitoring> monitorings8 = await _monitoringRepository.getStatusStockHours(nshop, 8);
            List<Monitoring> monitorings8m = await _monitoringRepository.getStatusStock30Minutes(nshop, 8);

            List<Monitoring> monitorings9 = await _monitoringRepository.getStatusStockHours(nshop, 9);
            List<Monitoring> monitorings9m = await _monitoringRepository.getStatusStock30Minutes(nshop, 9);

            List<Monitoring> monitorings10 = await _monitoringRepository.getStatusStockHours(nshop, 10);
            List<Monitoring> monitorings10m = await _monitoringRepository.getStatusStock30Minutes(nshop, 10);

            List<Monitoring> monitorings11 = await _monitoringRepository.getStatusStockHours(nshop, 11);
            List<Monitoring> monitorings11m = await _monitoringRepository.getStatusStock30Minutes(nshop, 11);

            List<Monitoring> monitorings12 = await _monitoringRepository.getStatusStockHours(nshop, 12);
            List<Monitoring> monitorings12m = await _monitoringRepository.getStatusStock30Minutes(nshop, 12);

            List<Monitoring> monitorings13 = await _monitoringRepository.getStatusStockHours(nshop, 13);
            List<Monitoring> monitorings13m = await _monitoringRepository.getStatusStock30Minutes(nshop, 13);

            List<Monitoring> monitorings14 = await _monitoringRepository.getStatusStockHours(nshop, 14);
            List<Monitoring> monitorings14m = await _monitoringRepository.getStatusStock30Minutes(nshop, 14);

            List<Monitoring> monitorings15 = await _monitoringRepository.getStatusStockHours(nshop, 15);
            List<Monitoring> monitorings15m = await _monitoringRepository.getStatusStock30Minutes(nshop, 15);

            List<Monitoring> monitorings16 = await _monitoringRepository.getStatusStockHours(nshop, 16);
            List<Monitoring> monitorings16m = await _monitoringRepository.getStatusStock30Minutes(nshop, 16);

            List<Monitoring> monitorings17 = await _monitoringRepository.getStatusStockHours(nshop, 17);
            List<Monitoring> monitorings17m = await _monitoringRepository.getStatusStock30Minutes(nshop, 17);

            List<Monitoring> monitorings18 = await _monitoringRepository.getStatusStockHours(nshop, 18);
            List<Monitoring> monitorings18m = await _monitoringRepository.getStatusStock30Minutes(nshop, 18);

            List<Monitoring> monitorings19 = await _monitoringRepository.getStatusStockHours(nshop, 19);
            List<Monitoring> monitorings19m = await _monitoringRepository.getStatusStock30Minutes(nshop, 19);

            List<Monitoring> monitorings20 = await _monitoringRepository.getStatusStockHours(nshop, 20);
            List<Monitoring> monitorings20m = await _monitoringRepository.getStatusStock30Minutes(nshop, 20);

            List<Monitoring> monitorings21 = await _monitoringRepository.getStatusStockHours(nshop, 21);
            List<Monitoring> monitorings21m = await _monitoringRepository.getStatusStock30Minutes(nshop, 21);

            List<Monitoring> monitorings22 = await _monitoringRepository.getStatusStockHours(nshop, 22);
            List<Monitoring> monitorings22m = await _monitoringRepository.getStatusStock30Minutes(nshop, 22);

            if (monitorings7.Count == 0) statusForDayResponseModel.Status7 = 0;
            if (monitorings7.Count != 0)
            {
                statusForDayResponseModel.Status7 = 1;
                foreach (Monitoring x in monitorings7)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status7 = -1;
                    }
                }
            }
            if (monitorings7m.Count == 0) statusForDayResponseModel.Status7m = 0;
            if (monitorings7m.Count != 0) 
            {
                statusForDayResponseModel.Status7m = 1;
                foreach (Monitoring x in monitorings7m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status7m = -1;
                    }
                }
            }

            if (monitorings8.Count == 0) statusForDayResponseModel.Status8 = 0;
            if (monitorings8.Count != 0)
            {
                statusForDayResponseModel.Status8 = 1;
                foreach (Monitoring x in monitorings8)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status8 = -1;
                    }
                }
            }
            if (monitorings8m.Count == 0) statusForDayResponseModel.Status8m = 0;
            if (monitorings8m.Count != 0)
            {
                statusForDayResponseModel.Status8m = 1;
                foreach (Monitoring x in monitorings8m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status8m = -1;
                    }
                }
            }

            if (monitorings9.Count == 0) statusForDayResponseModel.Status9 = 0;
            if (monitorings9.Count != 0)
            {
                statusForDayResponseModel.Status9 = 1;
                foreach (Monitoring x in monitorings9)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status9 = -1;
                    }
                }
            }
            if (monitorings9m.Count == 0) statusForDayResponseModel.Status9m = 0;
            if (monitorings9m.Count != 0)
            {
                statusForDayResponseModel.Status9m = 1;
                foreach (Monitoring x in monitorings9m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status9m = -1;
                    }
                }
            }

            if (monitorings10.Count == 0) statusForDayResponseModel.Status10 = 0;
            if (monitorings10.Count != 0)
            {
                statusForDayResponseModel.Status10 = 1;
                foreach (Monitoring x in monitorings10)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status10 = -1;
                    }
                }
            }

            if (monitorings10m.Count == 0) statusForDayResponseModel.Status10m = 0;
            if (monitorings10m.Count != 0)
            {
                statusForDayResponseModel.Status10m = 1;
                foreach (Monitoring x in monitorings10m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status10m = -1;
                    }
                }
            }

            if (monitorings11.Count == 0) statusForDayResponseModel.Status11 = 0;
            if (monitorings11.Count != 0) statusForDayResponseModel.Status11 = 1;
            {
                statusForDayResponseModel.Status11 = 1;
                foreach (Monitoring x in monitorings11)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status11 = -1;
                    }
                }
            }
            if (monitorings11m.Count == 0) statusForDayResponseModel.Status11m = 0;
            if (monitorings11m.Count != 0)
            {
                statusForDayResponseModel.Status11m = 1;
                foreach (Monitoring x in monitorings11m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status11m = -1;
                    }
                }
            }

            if (monitorings12.Count == 0) statusForDayResponseModel.Status12 = 0;
            if (monitorings12.Count != 0) 
            {
                statusForDayResponseModel.Status12 = 1;
                foreach (Monitoring x in monitorings12)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status12 = -1;
                    }
                }
            }

            if (monitorings12m.Count == 0) statusForDayResponseModel.Status12m = 0;
            if (monitorings12m.Count != 0)
            {
                statusForDayResponseModel.Status12m = 1;
                foreach (Monitoring x in monitorings12m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status12m = -1;
                    }
                }
            }

            if (monitorings13.Count == 0) statusForDayResponseModel.Status13 = 0;
            if (monitorings13.Count != 0)
            {
                statusForDayResponseModel.Status13 = 1;
                foreach (Monitoring x in monitorings13)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status13 = -1;
                    }
                }
            }
            if (monitorings13m.Count == 0) statusForDayResponseModel.Status13m = 0;
            if (monitorings13m.Count != 0)
            {
                statusForDayResponseModel.Status13m = 1;
                foreach (Monitoring x in monitorings13m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status13m = -1;
                    }
                }
            }

            if (monitorings14.Count == 0) statusForDayResponseModel.Status14 = 0;
            if (monitorings14.Count != 0)
            {
                statusForDayResponseModel.Status14 = 1;
                foreach (Monitoring x in monitorings14)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status14 = -1;
                    }
                }
            }
            if (monitorings14m.Count == 0) statusForDayResponseModel.Status14m = 0;
            if (monitorings14m.Count != 0)
            {
                statusForDayResponseModel.Status14m = 1;
                foreach (Monitoring x in monitorings14m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status14m = -1;
                    }
                }
            }

            if (monitorings15.Count == 0) statusForDayResponseModel.Status15 = 0;
            if (monitorings15.Count != 0)
            {
                statusForDayResponseModel.Status15 = 1;
                foreach (Monitoring x in monitorings15)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status15 = -1;
                    }
                }
            }

            if (monitorings15m.Count == 0) statusForDayResponseModel.Status15m = 0;
            if (monitorings15m.Count != 0)
            {
                statusForDayResponseModel.Status15m = 1;
                foreach (Monitoring x in monitorings15m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status15m = -1;
                    }
                }
            }

            if (monitorings16.Count == 0) statusForDayResponseModel.Status16 = 0;
            if (monitorings16.Count != 0)
            {
                statusForDayResponseModel.Status16 = 1;
                foreach (Monitoring x in monitorings16)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status16 = -1;
                    }
                }
            }
            if (monitorings16m.Count == 0) statusForDayResponseModel.Status16m = 0;
            if (monitorings16m.Count != 0)
            {
                statusForDayResponseModel.Status16m = 1;
                foreach (Monitoring x in monitorings16m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status16m = -1;
                    }
                }
            }

            if (monitorings17.Count == 0) statusForDayResponseModel.Status17 = 0;
            if (monitorings17.Count != 0)
            {
                statusForDayResponseModel.Status17 = 1;
                foreach (Monitoring x in monitorings17)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status17 = -1;
                    }
                }
            }
            if (monitorings17m.Count == 0) statusForDayResponseModel.Status17m = 0;
            if (monitorings17m.Count != 0)
            {
                statusForDayResponseModel.Status17m = 1;
                foreach (Monitoring x in monitorings17m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status17m = -1;
                    }
                }
            }

            if (monitorings18.Count == 0) statusForDayResponseModel.Status18 = 0;
            if (monitorings18.Count != 0) 
            {
                statusForDayResponseModel.Status18 = 1;
                foreach (Monitoring x in monitorings18)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status18 = -1;
                    }
                }
            }
            if (monitorings18m.Count == 0) statusForDayResponseModel.Status18m = 0;
            if (monitorings18m.Count != 0)
            {
                statusForDayResponseModel.Status18m = 1;
                foreach (Monitoring x in monitorings18m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status18m = -1;
                    }
                }
            }

            if (monitorings19.Count == 0) statusForDayResponseModel.Status19 = 0;
            if (monitorings19.Count != 0)
            {
                statusForDayResponseModel.Status19 = 1;
                foreach (Monitoring x in monitorings19)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status19 = -1;
                    }
                }
            }
            if (monitorings19m.Count == 0) statusForDayResponseModel.Status19m = 0;
            if (monitorings19m.Count != 0)
            {
                statusForDayResponseModel.Status19m = 1;
                foreach (Monitoring x in monitorings19m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status19m = -1;
                    }
                }
            }

            if (monitorings20.Count == 0) statusForDayResponseModel.Status20 = 0;
            if (monitorings20.Count != 0)
            {
                statusForDayResponseModel.Status20 = 1;
                foreach (Monitoring x in monitorings20)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status20 = -1;
                    }
                }
            }
            if (monitorings20m.Count == 0) statusForDayResponseModel.Status20m = 0;
            if (monitorings20m.Count != 0)
            {
                statusForDayResponseModel.Status20m = 1;
                foreach (Monitoring x in monitorings20m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status20m = -1;
                    }
                }
            }

            if (monitorings21.Count == 0) statusForDayResponseModel.Status21 = 0;
            if (monitorings21.Count != 0)
            {
                statusForDayResponseModel.Status21 = 1;
                foreach (Monitoring x in monitorings21)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status21 = -1;
                    }
                }
            }
            if (monitorings21m.Count == 0) statusForDayResponseModel.Status21m = 0;
            if (monitorings21m.Count != 0)
            {
                statusForDayResponseModel.Status21m = 1;
                foreach (Monitoring x in monitorings21m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status21m = -1;
                    }
                }
            }

            if (monitorings22.Count == 0) statusForDayResponseModel.Status22 = 0;
            if (monitorings22.Count != 0)
            {
                statusForDayResponseModel.Status22 = 1;
                foreach (Monitoring x in monitorings22)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status22 = -1;
                    }
                }
            }

            if (monitorings22m.Count == 0) statusForDayResponseModel.Status22 = 0;
            if (monitorings22m.Count != 0)
            {
                statusForDayResponseModel.Status22m = 1;
                foreach (Monitoring x in monitorings22m)
                {
                    if (x.Status == 0)
                    {
                        statusForDayResponseModel.Status22m = -1;
                    }
                }
            }

            return statusForDayResponseModel;
        }

         
        

        public async Task<DeviceInShopResponseModel> getDeviceinShop(int nshop)
        {
            DeviceInShopResponseModel deviceInShopResponseModel = new DeviceInShopResponseModel();

            List<string> deviceModels = await _monitoringRepository.getDevicesFromStock(nshop);

            List<Monitoring> devicesOnShop = new List<Monitoring>();

            foreach (string device in deviceModels)
            {
                Monitoring deviceOnShop = await _monitoringRepository.getDeviceFromLastLogTime(nshop,device);

                if (deviceOnShop != null){
                    
                    string dev = device.ToString();
                    char typeDevice = dev[0];

                    switch (typeDevice)
                    {
                        case 'D': deviceOnShop.Device = device.Substring(1).Insert(0, "Датчик дверей "); break;
                        case 'S': deviceOnShop.Device = device.Substring(1).Insert(0, "База магазину "); break;
                        case 'K': deviceOnShop.Device = device.Substring(1).Insert(0, "Каса "); break;
                        case 'V': deviceOnShop.Device = device.Substring(1).Insert(0, "Відеореєстратор "); break;
                        case 'P': deviceOnShop.Device = device.Substring(1).Insert(0, "PriceChecker "); break;
                        case 'M': deviceOnShop.Device = device.Substring(1).Insert(0, "Raspberry "); break;
                        case 'F': deviceOnShop.Device = device.Substring(1).Insert(0, "Принтер чеків "); break;
                        case 'T': deviceOnShop.Device = device.Substring(1).Insert(0, "Термінал "); break;
                    }                  

                    devicesOnShop.Add(deviceOnShop);
                }
            }

            List<MonitoringModel> devicesModels = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(devicesOnShop);

            devicesModels.ForEach(x => x.StrLogTime = x.LogTime.ToString());

            deviceInShopResponseModel.Devices = devicesModels;

            return deviceInShopResponseModel;
        }
    }
}
