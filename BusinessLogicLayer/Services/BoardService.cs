using AutoMapper;
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
        private readonly IStocksRepository _stocksRepository;
        private readonly IMapper _mapper;

        public BoardService (IDeviceRepository deviceRepository, IMonitoringRepository monitoringRepository, IStockRepository stockRepository, IStocksRepository stocksRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _monitoringRepository = monitoringRepository;
            _stockRepository = stockRepository;
            _stocksRepository = stocksRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseModel>> GetBoard()
        {
            List<Device> devices = await _deviceRepository.GetAllAsync();
            List<Monitoring> monitorings = await _monitoringRepository.GetAllAsync();
            List<Stock> stock = await _stockRepository.GetAllAsync();
            List<Stocks> stocks = await _stocksRepository.GetAllAsync();

            List<ResponseModel> boardModelResponse = _mapper.Map<List<Stock>, List<ResponseModel>>(stock);

            return boardModelResponse;
        }
    }
}
