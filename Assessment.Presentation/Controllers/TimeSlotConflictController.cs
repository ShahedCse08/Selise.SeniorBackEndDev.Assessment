using Assessment.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotConflictController : ControllerBase
    {

        [HttpGet("HasConflict")]
        [Produces("application/json")]
        public bool HasConflict()
        {
            var isConflicting = false;
            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {

            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 13, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 14, 30, 0)
            },
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 15, 30, 0),
            EndTime = new DateTime(2024, 8, 19, 16, 30, 0)
            }

            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime > slot.StartTime && givenSlot.StartTime < slot.EndTime || givenSlot.EndTime > slot.StartTime && givenSlot.EndTime < slot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isConflicting;
        }

        [HttpGet("HasNoConflict")]
        [Produces("application/json")]
        public bool HasNoConflict()
        {
            var isNotConflicting = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 12, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 13, 0, 0)
            },
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 16, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 17, 0, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime > slot.StartTime && givenSlot.StartTime < slot.EndTime || givenSlot.EndTime > slot.StartTime && givenSlot.EndTime < slot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isNotConflicting;
        }

        [HttpGet("ExactOverlap")]
        [Produces("application/json")]
        public bool ExactOverlap()
        {
            var isExactOverlap = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime == slot.StartTime && givenSlot.EndTime == slot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isExactOverlap;
        }

        [HttpGet("OverlappingStartTime")]
        [Produces("application/json")]
        public bool OverlappingStartTime()
        {
            var isOverlappingStartTime = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };


            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 13, 30, 0),
            EndTime = new DateTime(2024, 8, 19, 14, 30, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime >= slot.StartTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isOverlappingStartTime;
        }



        [HttpGet("OverlappingEndTime")]
        [Produces("application/json")]
        public bool OverlappingEndTime()
        {
            var isOverlappingEndTime = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 14, 30, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 30, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.EndTime <= slot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isOverlappingEndTime;
        }


        [HttpGet("GivenSlotCompletelyContainedWithinExistingSlot")]
        [Produces("application/json")]
        public bool GivenSlotCompletelyContainedWithinExistingSlot()
        {
            var isGivenSlotCompletelyContainedWithinExistingSlot = false;
            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 15, 0),
                EndTime = new DateTime(2024, 8, 19, 14, 45, 0)
            };


            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime > slot.StartTime && givenSlot.StartTime < slot.EndTime && givenSlot.EndTime > slot.StartTime && givenSlot.EndTime < slot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isGivenSlotCompletelyContainedWithinExistingSlot;
        }

        [HttpGet("ExistingSlotCompletelyContainedWithinGivenSlot")]
        [Produces("application/json")]
        public bool ExistingSlotCompletelyContainedWithinGivenSlot()
        {
            var isExistingSlotCompletelyContainedWithinGivenSlot = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 13, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 16, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            }
            };


            foreach (var slot in existingSlots)
            {
                if (slot.StartTime > givenSlot.StartTime && slot.StartTime < givenSlot.EndTime && slot.EndTime > givenSlot.StartTime && slot.EndTime < givenSlot.EndTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return isExistingSlotCompletelyContainedWithinGivenSlot;
        }


        [HttpGet("NoExistingTimeSlots")]
        [Produces("application/json")]
        public bool NoExistingTimeSlots()
        {
            var isNoExistingTimeSlots = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[] { };

            if (existingSlots.Count() == 0)
            {
                return isNoExistingTimeSlots;
            }

            return isNoExistingTimeSlots;

        }


        [HttpGet("StartTimeEqualsEndTime")]
        [Produces("application/json")]
        public bool StartTimeEqualsEndTime()
        {
            var isStartTimeEqualsEndTime = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 14, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 13, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            }
            };


            if (givenSlot.StartTime == givenSlot.EndTime)
            {
                return false;
            }

            return isStartTimeEqualsEndTime;
        }


        [HttpGet("StartTimeEqualsEndTimeofAnotherSlot")]
        [Produces("application/json")]
        public bool StartTimeEqualsEndTimeofAnotherSlot()
        {
            var isStartTimeEqualsEndTimeofAnotherSlot = false;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 13, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 14, 0, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime == slot.EndTime)
                {
                    return false;
                }

            }

            return isStartTimeEqualsEndTimeofAnotherSlot;
        }


        [HttpGet("MultipleConflicts")]
        [Produces("application/json")]
        public bool MultipleConflicts()
        {
            var isMultipleConflicts = false;
            var conflictCount = 0;

            TimeSlot givenSlot = new TimeSlot
            {
                StartTime = new DateTime(2024, 8, 19, 14, 0, 0),
                EndTime = new DateTime(2024, 8, 19, 15, 0, 0)
            };

            TimeSlot[] existingSlots = new TimeSlot[]
            {
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 13, 30, 0),
            EndTime = new DateTime(2024, 8, 19, 14, 30, 0)
            },
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 14, 45, 0),
            EndTime = new DateTime(2024, 8, 19, 15, 15, 0)
            },
            new TimeSlot
            {
            StartTime = new DateTime(2024, 8, 19, 16, 0, 0),
            EndTime = new DateTime(2024, 8, 19, 17, 0, 0)
            }
            };

            foreach (var slot in existingSlots)
            {
                if (givenSlot.StartTime > slot.StartTime && givenSlot.StartTime < slot.EndTime || givenSlot.EndTime > slot.StartTime && givenSlot.EndTime < slot.EndTime)
                {
                    conflictCount += 1;
                }
            }

            if (conflictCount > 1)
            {
                return true;
            }

            return isMultipleConflicts;
        }

    }
}
