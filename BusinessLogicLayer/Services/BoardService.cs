﻿using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class BoardService : IBoardService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMonitoringRepository _monitoringRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IRStockRepository _stocksRepository;
        private readonly IMapper _mapper;

        public BoardService (IDeviceRepository deviceRepository, IMonitoringRepository monitoringRepository, IStockRepository stockRepository, IRStockRepository stocksRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _monitoringRepository = monitoringRepository;
            _stockRepository = stockRepository;
            _stocksRepository = stocksRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> GetBoard()
        {
            ResponseModel responseModel = new ResponseModel();

            int amount = await _monitoringRepository.GetCountStock();
            List<Monitoring> monitoringsR = await _monitoringRepository.GetStockR(amount);
            List<Monitoring> monitoringsS = await _monitoringRepository.GetStockS(amount);

            responseModel.amount = amount;
            responseModel.monitoringModelsR = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(monitoringsR);
            responseModel.monitoringModelsS = _mapper.Map<List<Monitoring>, List<MonitoringModel>>(monitoringsS);

            return responseModel;
        }
    }
}
