using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SportsClubModel.CoreAbstractions.Async.UnitsOfWork;
using SportsClubModel.Domain;
using SportsClubWeb.DTO;

namespace SportsClubWeb.Controllers.api
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationAPIController : ControllerBase
    {
        private readonly ReservationUnitOfWorkAsync reservationUnitOfWork;
        private readonly IMapper autoMapper;
        private readonly LinkGenerator linkGenerator;
        public ReservationAPIController(ReservationUnitOfWorkAsync work, IMapper mapper, LinkGenerator generator )
        {
            reservationUnitOfWork = work;
            autoMapper = mapper;
            linkGenerator = generator;
        }
        public async Task<ActionResult<ReservationDTO[]>> Get()
        {
             var reservations =  await reservationUnitOfWork.ReservationRepository.ReservationsForDayAsync(DateTime.Now);
             var reservationDTOs = autoMapper.Map<ReservationDTO[]>(reservations);
             return reservationDTOs;
            
        }

         [HttpPost]
        public async Task<ActionResult<ReservationDTO>> Add(ReservationDTO dto)
        {
            var existingReservations = await reservationUnitOfWork.ReservationRepository
                         .ReservationsForCourtInDateIntervalAsync(dto.CourtId, dto.Start, dto.End);
            if(existingReservations.Length != 0)
            {
                return BadRequest("court not available");
            } 
            var location = linkGenerator.GetPathByAction("Get", "ReservationAPI", new { Id = dto.Id});
            var newReservation = autoMapper.Map<Reservation>(dto);
            reservationUnitOfWork.ReservationRepository.Add(newReservation);
            await reservationUnitOfWork.SaveAsync();
            return Created(location, autoMapper.Map<ReservationDTO>(newReservation));

        }
         
    }
}