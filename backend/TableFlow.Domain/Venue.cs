using System;

namespace TableFlow.Domain
{
    public class Venue
    {
        public int Id { get;}

        public int OrganizationId { get;}

        public string Name { get; private set; }

        public VenueType VenueType { get;}

        public string TimeZoneId { get;}

        public Venue(int id, int organizationId, string name, VenueType venueType, string timeZoneId)
        {
            ValidateId(id);
            Id = id;
            ValidateId(organizationId);
            OrganizationId = organizationId;

            if (IsValidName(name))

            {
                Name = name.Trim();
            }
            else
            {
                throw new ArgumentException("Invalid name. Name must be between 3 and 100 characters and cannot be empty or whitespace.");
            }

            if (Enum.IsDefined(venueType))
            {
                VenueType = venueType;

            }
            else
            {
                throw new ArgumentException("Invalid venue type.");

            }

            ValidateTimeZone(timeZoneId);
            TimeZoneId = timeZoneId;
        }

        public void ChangeName(string newName)
        {
            if (!IsValidName(newName))
            {
                throw new ArgumentException(
                    "Name must be between 3 and 100 characters.",
                    nameof(newName));
            }

            Name = newName.Trim();
        }

        private bool IsValidName(string name)
        { 

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            name = name.Trim();

            if (name.Length > 100 || name.Length <= 2)
            {
                return false;
            }
            return true;
        }

        private void ValidateTimeZone(string? timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
            {
                throw new ArgumentException("Time zone ID cannot be empty.", nameof(timeZoneId));
            }

            try
            {
                TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            }
            catch (TimeZoneNotFoundException ex)
            {
                throw new ArgumentException("Time zone ID was not found.", nameof(timeZoneId), ex);
            }
            catch (InvalidTimeZoneException ex)
            {
                throw new ArgumentException(
                    "Time zone data is invalid.",
                    nameof(timeZoneId),
                    ex);
            }
        }

        private void ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be a positive integer.");
            }
        }
    }
}
