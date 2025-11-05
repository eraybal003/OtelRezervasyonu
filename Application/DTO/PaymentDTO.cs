using Domain.Entites;

namespace Application.DTO;
public record PaymentDTO(Ulid id, Ulid reservationid, decimal amount,
    DateTime paymentday, string paymentmethod, string status, Reservation Reservation);
public record PaymentCreateDTO(decimal amount, string paymentmethod, string status);
public record PaymentUpdateDTO(decimal amount, string paymentmethod, string status);
public record PaymentDeleteDTO(Ulid id);
