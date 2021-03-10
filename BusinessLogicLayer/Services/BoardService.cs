﻿using AutoMapper;
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

        private readonly IShopsRepository _shopsRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IShopProvidersRepository _shopProvidersRepository;
        private readonly ITempImportAddressesRepository _tempImportAddressesRepository;
        private readonly IShopRegionLocalizationsRepository _shopRegionLocalizationsRepository;
        private readonly IShopWorkTimesRepository _shopWorkTimesRepository;

        private readonly IMapper _mapper;

        public BoardService (IMonitoringRepository monitoringRepository,
            IShopsRepository shopsRepository, IProviderRepository providerRepository,
            IShopProvidersRepository shopProvidersRepository, IShopRegionLocalizationsRepository shopRegionLocalizationsRepository,
            ITempImportAddressesRepository tempImportAddressesRepository, IShopWorkTimesRepository shopWorkTimesRepository,
            IMapper mapper)
        {
            _monitoringRepository = monitoringRepository;

            _shopsRepository = shopsRepository;
            _providerRepository = providerRepository;
            _shopProvidersRepository = shopProvidersRepository;
            _tempImportAddressesRepository = tempImportAddressesRepository;
            _shopWorkTimesRepository = shopWorkTimesRepository;
            _shopRegionLocalizationsRepository = shopRegionLocalizationsRepository;

            _mapper = mapper;
        }

        public async Task<BoardResponseModel> getBoard()
        {
            BoardResponseModel responseModel = new BoardResponseModel();

            int amount = await _monitoringRepository.getCountStock();
            List<int?> greenFrom5Day = await _monitoringRepository.getGreenFrom5Day();

            int?[] greyFrom5Day = new int?[amount+1];

            for (int i = 1; i <= amount; i++)
            {
                greyFrom5Day[i] = 1;

                for (int y = 0; y < greenFrom5Day.Count; y++)
                {

                    if (i == greenFrom5Day[y])
                    {
                        greyFrom5Day[i] = 0;
                    }
                }
            }

            List<Monitoring> monitoringsR = await _monitoringRepository.getStockR(amount);
            List<Monitoring> monitoringsS = await _monitoringRepository.getStockS(amount);

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

        public async Task<DeviceInShopResponseModel> getDeviceinShop(int nshop)
        {
            DeviceInShopResponseModel deviceInShopResponseModel = new DeviceInShopResponseModel();

            List<string> deviceModels = await _monitoringRepository.getDevicesFromStock(nshop);

            List<Monitoring> devicesOnShop = new List<Monitoring>();

            foreach (string device in deviceModels)
            {
                Monitoring deviceOnShop = await _monitoringRepository.getDeviceFromLastLogTime(nshop,device);
                if (deviceOnShop != null){
                    devicesOnShop.Add(deviceOnShop);
                }

                /* switch (device[0])
                 {
                     case 'R': device.Substring(1).Insert(0, "Роутер"); break;
                     case 'S': device.Substring(1).Insert(0, "База магазина"); break;
                     case 'K': device.Substring(1).Insert(0, "Касса "); break;
                     case 'V': device.Substring(1).Insert(0, "Видеорегистратор "); break;
                     case 'P': device.Substring(1).Insert(0, "PriceChecker"); break;
                     case 'M': device.Substring(1).Insert(0, "Raspberry"); break;
                     case 'F': device.Substring(1).Insert(0, "Принтер чеков"); break;
                     case 'T': device.Substring(1).Insert(0, "Терминал"); break;
                 }*/
            }

            List<MonitoringModel> devicesModels = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(devicesOnShop);

            deviceInShopResponseModel.Devices = devicesModels;

            return deviceInShopResponseModel;
        }
    }
}
