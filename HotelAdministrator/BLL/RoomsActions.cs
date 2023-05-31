using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace HotelAdministrator.BLL
{
    class RoomsActions
    {
        IMapper MRoom = new MapperConfiguration(cfg => cfg.CreateMap<Room, Room>()).CreateMapper();
        IMapper MStatus = new MapperConfiguration(cfg => cfg.CreateMap<Status, Status>()).CreateMapper();
        private readonly UnitOfWork uow;

        public RoomsActions()
        {
            Context c = new Context();
            uow = new UnitOfWork(c, new ContextRepository<Room>(c), new ContextRepository<Status>(c));
        }


        public List<Room> GetRooms()
        {
            return MRoom.Map<IEnumerable<Room>, List<Room>>(uow.Rooms.Get());
        }

        public List<Status> GetStatuses()
        {
            return MStatus.Map<IEnumerable<Status>, List<Status>>(uow.Statuses.Get());
        }


        public Room GetRoomById(int id)
        {
            return MRoom.Map<Room, Room>(uow.Rooms.GetOne(x => (x.ID == id)));
        }

        public bool AddRoom(Room newroom)
        {
            uow.Rooms.Create(new Room() { Category = newroom.Category , DateTo = newroom.DateTo , Day_Price = newroom.Day_Price , Status_FK = newroom.Status_FK});
            uow.Save();
            return true;
        }

        public bool DeleteRoomByID(int id)
        {
            uow.Rooms.Remove(uow.Rooms.FindById(id));
            uow.Save();
            return true;
        }


        public bool ChangeRoom(Room newroom)
        {

            uow.Rooms.Update(new Room() { DateTo = newroom.DateTo , Day_Price = newroom.Day_Price , Status_FK = newroom.Status_FK , ID = newroom.ID});
            uow.Save();
            return true;
        }

        public bool SaveThis()
        {
            uow.Save();
            return true;
        }
    }
}
