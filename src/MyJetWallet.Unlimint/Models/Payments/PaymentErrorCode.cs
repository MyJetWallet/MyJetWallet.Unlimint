namespace MyJetWallet.Unlimint.Models.Payments
{
// https://cardpay.atlassian.net/wiki/spaces/SUP/pages/160727065/Decline+reasons    
//
// 1	System malfunction	Error request details to Unlimint. Relates mostly to non-card payment methods
// 2	Cancelled by customer	Customer cancelled the payment before finishing the transaction
// 3	Declined by Antifraud	Decline by Unlimint Antifraud system because of AF rules violation (suspicious customer's behavior + your account risk restrictions)
// 4	Declined by 3-D Secure	3DS check not passed
// 5	Only 3-D Secure transactions are allowed	3DS result didn't meet wallet requirements
// 6	3-D Secure availability is unknown	Issuer could not respond correctly on 3DS check, wallet settings don't allow such 3DS. Temporary decline
// 7	Limit reached	Your account in Unlimint has no balance to process payouts and refunds
// 8	Requested operation is not supported	Service is not allowed/supported for your account in Unlimint (including card types, limits and countries blocks)
// 10	Declined by bank (reason not specified)	No exact decline reason received from external system. Refers mostly to non-card methods.
// 11	Common decline by bank	Issuer or IPS declined with different reasons, need to contact bank. Also can be checked additionally by Unlimint support
// 12	Soft decline: EMV 3DS Authentication required	A Soft decline is a temporary authorization failure which may succeed after a subsequent retry with additional authentication (transaction is identified as too risky or suspicious to be accepted by the issuer). If such decline occurs, you may retry completing a transaction by sending a new payment request with the same data as in the original request during 10 minutes after the response Soft decline was received.
// 13	Insufficient funds	No funds on cardholder's balance or for this specific payment type. Issuer's response.
// 14	Card limit reached	Cardholder's account limit reached - Issuer side
// 15	Incorrect card data	Invalid PAN, CVV, transaction not supported by card. Issuer's response
// 16	Declined by bank’s antifraud	Antifraud triggered - Issuer or IPS side. Also includes lost or stolen card
// 17	Bank’s malfunction	Issuer or IPS cannot process the transaction at the moment. Temporary decline
// 18	Connection problem	
// No connection with the IPS or Issuer.
//
// 21	No payment was received (for BITCOIN payment method only)	The customer cancelled a payment or closed the page. Timeout triggered.
// 22	Wrong payment was received (for BITCOIN payment method only)	Wrong amount/payment details were indicated
// 23	Confirmations payment timeout (for BITCOIN payment method only)	No needed number of confirmation received during needed time period (Unlimint manager can procide more details on your settings)
    public enum PaymentErrorCode
    {        
        Ok = 0,
        SystemMalfunction = 1,
        CancelledByCustomer = 2,
        DeclinedByAntifraud = 3,
        DeclinedBy3DSecure = 4,
        Only3DSecureTransactionsAllowed = 5,
        Availability3DSecureUnknown = 6,
        LimitReached = 7,
        RequestedOperationNotSupported = 8,
        DeclinedByBank = 10,
        CommonDeclineByBank = 11,
        SoftDecline = 12,
        InsufficientFunds = 13,
        CardLimitReached = 14,
        IncorrectCardData = 15,
        DeclinedByBankAntifraud = 16,
        BankMalfunction = 17,
        ConnectionProblem = 18,
        IncorrectPaymentData = 19,
        BitcoinNoPaymentReceived = 21,
        BitcoinWrongPaymentReceived = 22,
        BitcoinConfirmationsPaymentTimeout = 23,
        MaximumAmountLimitExceeded = 25,
    }
}