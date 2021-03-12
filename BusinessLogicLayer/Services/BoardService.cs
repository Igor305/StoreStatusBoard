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

        public async Task<StatusForDayResponseModel> getStatusForDay(int nshop, int hour)
        {
            StatusForDayResponseModel statusForDayResponseModel = new StatusForDayResponseModel();

            List<Monitoring> monitorings = await _monitoringRepository.getStatusStockFromHours(nshop, hour);

            List<MonitoringModel> monitoringModels = _mapper.Map<List<Monitoring>, List < MonitoringModel >> (monitorings);

            statusForDayResponseModel.monitorings = monitoringModels;

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
